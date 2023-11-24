using UnityEngine;

public class Snake_movement : MonoBehaviour
{
    public float speed = 1f;
    private new Rigidbody2D rigidbody;
    private bool isFacingRight = true;
    private float platformWidth;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0; // Disable gravity to prevent falling

        // Replace the value below with the actual x-scale of your platform
        platformWidth = 3.2077f;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float horizontalMovement = isFacingRight ? 1 : -1;
        Vector2 targetVelocity = new Vector2(horizontalMovement * speed, rigidbody.velocity.y);
        rigidbody.velocity = targetVelocity;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cactus" || other.tag == "Flag")
        {
            Flip();
            Debug.Log("Collided with " + other.tag);
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
