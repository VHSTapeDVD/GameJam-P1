using UnityEngine;

public class Level5spoder : MonoBehaviour
{
    public float speed = 1f;
    private new Rigidbody2D rigidbody;
    private bool isFacingRight = true;
    private float platformWidth;
    public LayerMask groundLayerMask;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0;
        platformWidth = 2f;
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

        if (ShouldFlip())
        {
            Flip();
        }
    }

    bool ShouldFlip()
    {
        float raycastDistance = 0.4f;
        float raycastDirection = isFacingRight ? 1f : -1f;
        Vector2 raycastOrigin = transform.position + Vector3.right * (raycastDirection * platformWidth / 2);

        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.down, raycastDistance, groundLayerMask);

        // Flip only if not on the ground
        return hit.collider == null;
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
