using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;

    [Header("# GameControl")]
    public float time;

    [Header("# Player Stat")]
    //public int playerLife = 1;
    public float bsTime = 0.5f;
    public int damage = 10;
    public int sgDamage = 12;
    public int playerLevel;
    public int kill;


    [Header("# GameObject Manager")]
    public ItemManagerPool itemPool;


    //bool isPlayerHit = false; 
    

    private void Awake()
    {
        instance = this;
    }





    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    void GameStart()
    {

    }

    void GameOver()
    {

    }
}
