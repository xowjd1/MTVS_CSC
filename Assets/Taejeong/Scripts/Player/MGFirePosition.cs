using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MGFirePosition : MonoBehaviour
{
    // 기존 총알 발사랑 같지만
    // 스폰 포지션에 랜덤값을 부여한다.

    public GameManager gameManager;
    public PlayerHit player;
    public GameObject bulletFactory;
    public float bulletSpawnTime; // 총알 발사 주기 시간
    float currentTime;


    void Start()
    {
        // bulletSpawnTime 은 플레이어의 bsTime 이다.
        bulletSpawnTime = player.mgbsTime;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= bulletSpawnTime)
        {
            Fire();
            currentTime = 0;
        }
    }



    private void Fire()
    {
        Vector3 randomOffset = new Vector3(Random.Range(-0.15f, 0.15f), Random.Range(-0.15f, 0.15f), Random.Range(-0.15f, 0.15f));
        Vector3 spawnPosition = transform.position + randomOffset;

        GameObject bullet = Instantiate(bulletFactory, spawnPosition, Quaternion.identity);
    }


}
