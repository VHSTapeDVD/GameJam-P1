using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spoder_movement : MonoBehaviour
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

        // Check if the Snake is at the edge of the platform
        if (ShouldFlip())
        {
            Flip();
        }
    }

    bool ShouldFlip()
    {
        float raycastDistance = 0.2f; // Adjust this value based on your platform's scale
        Vector2 raycastOrigin = isFacingRight ? transform.position + Vector3.right * (platformWidth / 2) : transform.position - Vector3.right * (platformWidth / 2);
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.down, raycastDistance);

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

