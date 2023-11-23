using UnityEngine;
using System.Collections;

public class Spider_Enemy : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float knockoutForce = 10f;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingLeft = false;
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingLeft = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (IsPlayerAboveSpider(collision.transform.position.y))
            {
                KnockoutSpider();
            }
            else
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }

    private bool IsPlayerAboveSpider(float playerY)
    {
        return playerY > transform.position.y + 0.5f;
    }

    private void KnockoutSpider()
    {
        Rigidbody2D spiderRigidbody = GetComponent<Rigidbody2D>();
        spiderRigidbody.velocity = new Vector2(0f, knockoutForce);
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(DisableSpiderAfterTime(2f));
    }

    private IEnumerator DisableSpiderAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
