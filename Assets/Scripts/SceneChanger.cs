using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has a specific tag or layer if needed
        // For example, only trigger when colliding with an object with the "Flag" tag
        if (other.CompareTag("Player"))
        {
            // Load the specified scene
            LoadLevelScene();
        }
    }

    // Method to load the specified scene
    public void LoadLevelScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
