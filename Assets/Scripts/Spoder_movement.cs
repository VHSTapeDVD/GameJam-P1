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

        // Check if the Spoder should flip
        if (ShouldFlip())
        {
            Flip();
        }
    }

    bool ShouldFlip()
    {
        float raycastDistance = 0.2f; // Adjust this value based on your platform's scale
        float raycastDirection = isFacingRight ? 1f : -1f;
        Vector2 raycastOrigin = transform.position + Vector3.right * (raycastDirection * platformWidth / 2);

        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.down, raycastDistance);

        // Check if the object it hits is tagged as "Flag"
        if (hit.collider != null && hit.collider.CompareTag("Flag"))
        {
            return false; // Don't flip if it's a "Flag"
        }

        // Check if the object it hits is tagged as "Untagged" or any other tag you want to treat the same
        if (hit.collider != null && hit.collider.CompareTag("Untagged"))
        {
            return true; // Flip if it's "Untagged"
        }

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