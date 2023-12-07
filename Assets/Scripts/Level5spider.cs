using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;  // Adjust this value to set the speed of the enemy
    public Transform groundCheck;  // Attach an empty GameObject to the bottom of the enemy to check if it's grounded
    public LayerMask groundLayer;  // Set this layer to the one your ground objects belong to

    private Rigidbody2D rb;
    private bool isFacingRight = true;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if the enemy is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Flip the enemy if it reaches the edge of a platform
        if (!isGrounded)
        {
            Flip();
        }

        // Move the enemy
        Move();
    }

    private void Move()
    {
        // Move the enemy horizontally
        if (isFacingRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }

    private void Flip()
    {
        // Flip the enemy's facing direction
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
