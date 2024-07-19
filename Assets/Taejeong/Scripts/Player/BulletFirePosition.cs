using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFirePosition : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject muzzleSpawn;
    public float bulletSpawnTime; // 총알 발사 주기 시간
    float currentTime;

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= bulletSpawnTime)
        {
            Fire();
            currentTime = 0;
        }

    }

    void Fire()
    {
        // 총알을 현재 스폰 포인트에서 소환
        GameObject bullet = Instantiate(bulletFactory, transform.position, Quaternion.identity);
        GameObject muzzle = Instantiate(muzzleSpawn, transform.position, Quaternion.identity);
    }
}
