using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2snake : MonoBehaviour

{
    public float speed = 1f;
    private new Rigidbody2D rigidbody;
    private bool isFacingRight = true;
    private float platformWidth;


    public LayerMask obstacleLayerMask;

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
        float horizontalMovement = isFacingRight ? 2 : -2;
        Vector2 targetVelocity = new Vector2(horizontalMovement * speed, rigidbody.velocity.y);
        rigidbody.velocity = targetVelocity;


        if (ShouldFlip())
        {
            Flip();
        }
    }

    /// <summary>
    /// Checks if the enemy should turn around
    /// </summary>
    /// <returns></returns>
    bool ShouldFlip()
    {
        float raycastDistance = 0.3f;
        float raycastDirection = isFacingRight ? 2f : -2f;
        Vector2 raycastOrigin = transform.position + Vector3.right * (raycastDirection * platformWidth / 4);


        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.down, raycastDistance, ~obstacleLayerMask);


        if (hit.collider != null && hit.collider.CompareTag("Flag"))
        {
            return false; // Don't flip if it's a "Flag"
        }

        // Check if the object it hits is tagged as "Untagged" or "Spoder"
        if (hit.collider != null && (hit.collider.CompareTag("Untagged") || hit.collider.CompareTag("Spider")))
        {
            return true; // Flip if it's "Untagged" or "Spoder"
        }

        // Check if there's an obstacle in front
        Vector2 obstacleCheckOrigin = transform.position + Vector3.right * (raycastDirection * platformWidth / 4 + raycastDirection * 0.4f);
        RaycastHit2D obstacleHit = Physics2D.Raycast(obstacleCheckOrigin, new Vector2(raycastDirection, 0), raycastDistance, ~obstacleLayerMask);

        return obstacleHit.collider != null;
    }

  
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
