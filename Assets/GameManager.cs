using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject gameOver, KangeeHead0, KangeeHead1, KangeeHead2, KangeeHead3;
    public static int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 4;
        KangeeHead0.gameObject.SetActive(true);
        KangeeHead1.gameObject.SetActive(true);
        KangeeHead2.gameObject.SetActive(true);
        KangeeHead3.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (health)
        {
            case 4:
                KangeeHead0.gameObject.SetActive(true);
                KangeeHead1.gameObject.SetActive(true);
                KangeeHead2.gameObject.SetActive(true);
                KangeeHead3.gameObject.SetActive(true);
                break;

            case 3:
                KangeeHead0.gameObject.SetActive(true);
                KangeeHead1.gameObject.SetActive(true);
                KangeeHead2.gameObject.SetActive(true);
                KangeeHead3.gameObject.SetActive(false);
                break;

            case 2:
                KangeeHead0.gameObject.SetActive(true);
                KangeeHead1.gameObject.SetActive(true);
                KangeeHead2.gameObject.SetActive(true);
                KangeeHead3.gameObject.SetActive(false);
                break;

            case 1:
                KangeeHead0.gameObject.SetActive(true);
                KangeeHead1.gameObject.SetActive(true);
                KangeeHead2.gameObject.SetActive(false);
                KangeeHead3.gameObject.SetActive(false);
                break;

            case 0:
                KangeeHead0.gameObject.SetActive(true);
                KangeeHead1.gameObject.SetActive(true);
                KangeeHead2.gameObject.SetActive(false);
                KangeeHead3.gameObject.SetActive(false);
                break;

            default:
                KangeeHead0.gameObject.SetActive(false);
                KangeeHead1.gameObject.SetActive(false);
                KangeeHead2.gameObject.SetActive(false);
                KangeeHead3.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);
                Time.timeScale = 0;
                break;
        }
    }
}
