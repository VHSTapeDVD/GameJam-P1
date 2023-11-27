using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EntityMovement : MonoBehaviour
{
    public float speed = 1f;
    public Vector2 direction = Vector2.left;

    private new Rigidbody2D rigidbody;
    private Vector2 velocity;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        // enabled = false; // Comment or remove this line
    }

    private void FixedUpdate()
    {
        // Calculate horizontal movement
        velocity.x = direction.x * speed;

        // Apply gravity
        velocity.y += Physics2D.gravity.y * Time.fixedDeltaTime;

        // Move the entity
        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);

        // Raycast to detect collisions and change direction
        if (Raycast(direction))
        {
            direction = -direction;
        }

        // Raycast downwards to handle grounding
        if (Raycast(Vector2.down))
        {
            velocity.y = Mathf.Max(velocity.y, 0f);
        }

        // Update rotation based on movement direction
        UpdateRotation();
    }

    // Method to update the rotation of the entity
    private void UpdateRotation()
    {
        if (direction.x > 0f)
        {
            transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        }
        else if (direction.x < 0f)
        {
            transform.localEulerAngles = Vector3.zero;
        }
    }

    // Raycast method for detecting collisions
    private bool Raycast(Vector2 castDirection)
    {
        if (rigidbody.isKinematic)
        {
            return false;
        }

        float radius = 0.25f;
        float distance = 0.375f;

        // Use CircleCast to detect collisions
        RaycastHit2D hit = Physics2D.CircleCast(rigidbody.position, radius, castDirection.normalized, distance);
        return hit.collider != null && hit.rigidbody != rigidbody;
    }
}
