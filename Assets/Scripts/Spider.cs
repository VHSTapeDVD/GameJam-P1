using UnityEngine;

public class GoombaScript : MonoBehaviour
{
    public Sprite flatsprite;
    private bool isFlattened = false;

    public bool IsFlattened()
    {
        return isFlattened;
    }

    public void Flatten()
    {
        if (!isFlattened)
        {
            isFlattened = true;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Spider1_movement>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = flatsprite;
            Destroy(gameObject, 5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            if (collision.contactCount > 0)
            {
                Vector2 collisionNormal = collision.GetContact(0).normal;
                float dotProduct = Vector2.Dot(collisionNormal, Vector2.up);

                if (dotProduct > 0.8f)
                {
                    // Top collision - Flatten and destroy after 5 seconds
                    Flatten();
                }
                else if (Mathf.Abs(collisionNormal.x) > 0.8f)
                {
                    // Side collision - Player takes damage (you need to implement this)
                    Health playerHealth = collision.gameObject.GetComponent<Health>();
                    if (playerHealth != null)
                    {
                        playerHealth.TakeDamage(1f); // Pass the appropriate damage amount
                    }
                }
            }
        }
    }
}
