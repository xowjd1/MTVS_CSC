using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;

    public GameObject enemySpawner;

    [Header("★ 총알 기본 데미지")]
    public int damage = 10;
    public int sgDamage = 12;
    public int mgDamage = 3;
    [Header("★ 플레이어 스탯")]
    public int kill;
    
    public bool isShotGun = false;
    public bool isShotGun5 = false;
    public bool isShotGunEnd = false;

    [Header("★ 게임 시스템 매니저")]
    float currentTime;
    public float enemyStopSpawnTime;
   


    

    private void Awake()
    {
        instance = this;
    }



    void Start()
    {
        
    }

   
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= enemyStopSpawnTime)
            enemySpawner.SetActive(false);

        if(isShotGun5)
        {
            isShotGun = false;
        }

    }

    void GameStart()
    {

    }

    void GameOver()
    {

    }
}
