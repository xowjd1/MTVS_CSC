using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePosition : MonoBehaviour
{
    public GameObject bulletFactory;
    public float bulletSpawnTime;

    void Start()
    {
        InvokeRepeating("Fire", 0f, bulletSpawnTime);  // "SpawnEnemy" 함수를 0초 후에 시작하고, 2초 간격으로 반복 호출
    }


    void Fire()
    {
        Instantiate(bulletFactory, transform.position, Quaternion.identity);  // 적을 현재 스폰 포인트에서 소환
    }
}
