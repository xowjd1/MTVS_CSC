using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("# GameControl")]
    public float time;

    [Header("# Player Stat")]
    public int playerLevel;
    public int kill;


    [Header("# GameObject Manager")]
    public ItemManagerPool itemPool;
    

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
