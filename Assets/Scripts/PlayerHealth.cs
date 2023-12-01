using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Private variable for the players health
    private int health;

    // Public method called with the players dealth
    public void Die()
    {
        // The players health is set to 0
        health = 0;

        // Checking if the players health is less than or equal to 0
        if (health <= 0)
        {
            //Destroy the gameobject if health is 0
            Destroy(gameObject);

            // Load the GameOver scene with Unity's SceneManager
            SceneManager.LoadScene("GameOver");
        }
    }
}
