using UnityEngine;

public class Snake : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth health = other.GetComponent<PlayerHealth> ();

            if (health != null)
            {
                health.TakeDamage(1); // Pass the amount of damage as an argument
            }
        }
    }
}
