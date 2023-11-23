using System.Collections;
using UnityEngine;

public class Spider_Enemy : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float knockoutForce = 10f;
    private bool movingleft;
    private float leftEdge;
    private float rightEdge;

    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }

    private void Update()
    {
        if (movingleft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingleft = false;
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingleft = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            Health playerHealth = collision.GetComponent<Health>();


            if (IsPlayerAboveSpider(collision.transform.position.y))
            {

                Rigidbody2D spiderRigidbody = GetComponent<Rigidbody2D>();
                spiderRigidbody.velocity = new Vector2(0f, knockoutForce);
                GetComponent<Collider2D>().enabled = false;
                StartCoroutine(DisableSpiderAfterTime(2f));

         
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

    private IEnumerator DisableSpiderAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
