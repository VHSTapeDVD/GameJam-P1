using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxhealth = 1;
    public int health;

    void Awake()
    {
        health = maxhealth;
    }

    public void TakeDamage(float damage)
    {

        int roundedDamage = Mathf.RoundToInt(damage);

        health -= roundedDamage;


        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
