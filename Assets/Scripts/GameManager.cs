using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public GameObject KangeeHead1, KangeeHead2, KangeeHead3, gameOver;
    public int health;


    private void Awake()
    {
        Instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        KangeeHead1.gameObject.SetActive(true);
        KangeeHead2.gameObject.SetActive(true);
        KangeeHead3.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 3)
            health = 3;

        
    }
}
