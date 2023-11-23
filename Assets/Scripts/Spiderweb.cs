using UnityEngine;

public class Spiderweb : MonoBehaviour
{
    public float bounceForce = 20f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D otherRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

        if (otherRigidbody != null)
        {
            // Apply a vertical impulse force to the collided object
            otherRigidbody.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }
    }
}
