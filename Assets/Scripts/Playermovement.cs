using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private float jumpForce = 17f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool grounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null) Debug.LogError("Rigidbody2D component is missing!");

        animator = GetComponent<Animator>();
        if (animator == null) Debug.LogError("Animator component is missing!");

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null) Debug.LogError("SpriteRenderer component is missing!");
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleJump();
    }

    void HandleMovement()
    {
        rb.velocity = new Vector2(GetMovementInput().x * speed, rb.velocity.y);
        UpdateAnimator();
        FlipSprite();
    }

    void HandleJump()
    {
        if (grounded && ShouldJump())
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
            grounded = false;
        }
    }

    Vector2 GetMovementInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
    }

    void UpdateAnimator()
    {
        if (GetMovementInput().x != 0)
            animator.SetFloat("x", GetMovementInput().x);
        else
            animator.SetBool("isWalking", false);
    }

    void FlipSprite()
    {
        spriteRenderer.flipX = GetMovementInput().x < 0f;
    }

    bool ShouldJump()
    {
        return Input.GetButtonDown("Jump");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            animator.SetBool("isJumping", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (!Physics2D.OverlapCircle(transform.position, 0.1f, groundLayer))
        {
            grounded = false;
        }
    }
}
