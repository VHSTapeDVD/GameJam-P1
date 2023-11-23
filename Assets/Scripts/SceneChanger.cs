using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;

    // OnTriggerEnter is called when the Collider other enters the trigger.
    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has a specific tag or layer if needed
        // For example, only trigger when colliding with an object with the "Player" tag
        if (other.CompareTag("Flag"))
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