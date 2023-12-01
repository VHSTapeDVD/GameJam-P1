using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Public method called with the "Try Again" functionality
    public void TryAgain()
    {
        // Load the scene Level 1 with Unitys SceneManager
        SceneManager.LoadScene("Level 1");
    }
}
