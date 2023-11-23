using UnityEngine;
using System.Collections;

public class Spider1_movement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 5f; // Adjust this value as needed
    private new Rigidbody2D rigidbody;
    private bool isFacingRight = true;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(ContinuousMoveAndJump());
    }

    private void FixedUpdate()
    {
        // Check if the Spider is at the edge of the platform
        if (ShouldFlip())
        {
            Flip();
        }
    }

    private bool ShouldFlip()
    {
        float raycastDistance = 0.2f; // Adjust this value based on your platform's scale
        Vector2 raycastOrigin = isFacingRight ? transform.position + Vector3.right * 1.6f : transform.position - Vector3.right * 1.6f;
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.down, raycastDistance);

        return hit.collider == null;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private IEnumerator ContinuousMoveAndJump()
    {
        yield return new WaitForSeconds(1f); // Adjust the delay as needed

        while (true)
        {
            Move();
            yield return new WaitForSeconds(1f); // Adjust the delay between move and jump
            Jump();
            yield return null;
        }
    }

    private void Move()
    {
        float horizontalMovement = isFacingRight ? 1 : -1;
        Vector2 targetVelocity = new Vector2(horizontalMovement * speed, rigidbody.velocity.y);
        rigidbody.velocity = targetVelocity;
        Debug.Log("Spider Moving"); // Debug statement for checking if Move is called
    }

    private void Jump()
    {
        rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        Debug.Log("Spider Jumping"); // Debug statement for checking if Jump is called
    }
}
