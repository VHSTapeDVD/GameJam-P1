using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiderweb : MonoBehaviour
{
    private float bounce = 20f;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
    }




}
