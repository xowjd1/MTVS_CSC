using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePosition : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerHit player;
    public GameObject bulletFactory;
    public float bulletSpawnTime;
    // public float maxBulletSpawnTime = 0.4f;
    float currentTime;

    
    void OnEnable()
    {
        
    }

 
    void Start()
    {

        // InvokeRepeating("Fire", 0f, bulletSpawnTime);  // "SpawnEnemy" 함수를 0초 후에 시작하고, 0.5f초 간격으로 반복 호출
        bulletSpawnTime = player.bsTime;
     

    }

    private void Update()
    {
        bulletSpawnTime = player.bsTime;
        currentTime += Time.deltaTime;

        if( currentTime >= bulletSpawnTime )
        {
            Fire();
            currentTime = 0;
        }
    }

    void Fire()
    {
        GameObject bullet =  Instantiate(bulletFactory, transform.position, Quaternion.identity);  // 적을 현재 스폰 포인트에서 소환
        
    }
}
