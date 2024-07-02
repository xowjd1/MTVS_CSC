using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;

    [Header("★ 총알 기본 데미지")]
    public int damage = 10;
    public int sgDamage = 12;
    [Header("★ 플레이어 스탯")]
    //public int playerLife = 1;
    public int kill;

    [Header("★ 게임 시스템 매니저")]
    public float time;
   


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
