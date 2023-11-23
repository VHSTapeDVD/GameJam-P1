using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public string sceneName;

    private void OntriggerEnter(Collider other)
    {

        if (other.CompareTag("Flag"))
        {
            SceneManager.LoadScene(sceneName);

        }


    }
 
}
