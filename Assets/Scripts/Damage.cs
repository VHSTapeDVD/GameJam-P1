using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
   // reference to the PlayerHealth script
   public PlayerHealth playerHealth;


   //is called when collision with 2D object
   private void OnCollisionEnter2D(Collision2D collision)
    {
        //checking if the collided object has the tag "Player"
        if(collision.gameObject.tag == "Player")
        {
            //if this is the case then call the method Die from the script PlayerHealth
            playerHealth.Die();
        }
    }
}


