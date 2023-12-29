using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7f;
    public float jumpForce = 17f;
    private bool isFacingRight = true;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true; // Freeze rotation along all axes

        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        if (rb.velocity.x != 0 && isGrounded)
        {
            myAnimator.SetBool("isWalking", true);
        }
        else
            myAnimator.SetBool("isWalking", false);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            myAnimator.SetBool("isJumping", true);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; 
        }
        

        Flip(horizontalInput);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is grounded
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            myAnimator.SetBool("isJumping", false);
        }
    }


    
    private void Flip(float horizontalInput)
    {
        // Check if the direction has changed
        if ((horizontalInput > 0 && !isFacingRight) || (horizontalInput < 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;

            // Flip the player's sprite
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
