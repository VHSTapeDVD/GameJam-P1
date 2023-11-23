using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxhealth = 10;
    public int health;

    public GameObject KangeeHead1, KangeeHead2, KangeeHead3, gameOver;

    // Start is called before the first frame update
    void Awake()
    {
        health = maxhealth;
        //GameManager.Instance.health = health;

        KangeeHead1.gameObject.SetActive(true);
        KangeeHead2.gameObject.SetActive(true);
        KangeeHead3.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
    }

    private void Update()
    {
        GameManager.Instance.health = health;
    }

    public void TakeDamage(float damage)
    {

        int roundedDamage = Mathf.RoundToInt(damage);

        health -= roundedDamage;
        
        switch (health)
        {
            case 3:
                
                KangeeHead1.gameObject.SetActive(true);
                KangeeHead2.gameObject.SetActive(true);
                KangeeHead3.gameObject.SetActive(true);
                break;

            case 2:
                KangeeHead1.gameObject.SetActive(true);
                KangeeHead2.gameObject.SetActive(true);
                KangeeHead3.gameObject.SetActive(false);
                break;

            case 1:
                KangeeHead1.gameObject.SetActive(true);
                KangeeHead2.gameObject.SetActive(false);
                KangeeHead3.gameObject.SetActive(false);
                break;

            case 0:
                Debug.Log("Det her er lort");
                KangeeHead1.gameObject.SetActive(false);
                KangeeHead2.gameObject.SetActive(false);
                KangeeHead3.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);
                Time.timeScale = 0;
                break;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
