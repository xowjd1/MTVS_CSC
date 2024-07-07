using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePosition : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerHit player;
    public GameObject bulletFactory;
    public float bulletSpawnTime; // 총알 발사 주기 시간
    float currentTime;
    public bool isShotGun = false; // 샷건인가
    public bool isShotGunFive = false; // 5발 샷건인가



    void Start()
    {
        // bulletSpawnTime 은 플레이어의 bsTime 이다.
        isShotGun = GameManager.instance.isShotGun;
        isShotGunFive = GameManager.instance.isShotGun5;
        bulletSpawnTime = player.bsTime;
    }

    private void Update()
    {
        // bulletSpawnTime 은 플레이어의 bsTime 이다. 실시간 업데이트
        bulletSpawnTime = player.bsTime;
        isShotGun = GameManager.instance.isShotGun;
        isShotGunFive = GameManager.instance.isShotGun5;

        currentTime += Time.deltaTime;

        if (isShotGun)
        {
            bulletSpawnTime = player.sgTime;
            if (currentTime >= bulletSpawnTime)
            {
                SGFire();
                currentTime = 0;
            }
        }
        else if (isShotGunFive)
        {
            bulletSpawnTime = player.sgTime;
            if (currentTime >= bulletSpawnTime)
            {
                SGFireFIve();
                currentTime = 0;
            }
        }
        else
        {
            isShotGun = false;
            isShotGunFive = false;
            bulletSpawnTime = player.bsTime;
            if (currentTime >= bulletSpawnTime)
            {
                Fire();
                currentTime = 0;
            }
            
        }
    }

    void Fire()
    {
        // 총알을 현재 스폰 포인트에서 소환
        GameObject bullet =  Instantiate(bulletFactory, transform.position, Quaternion.identity);  
    }

    void SGFire()
    {
        Debug.Log("SG");
        // 샷건 발사 (여러 발의 총알을 한 번에 발사)
        // 총알 생성 위치 설정
        Vector3 spawnPosition = transform.position;

        // 기본 방향 설정 (예: 오른쪽 방향)
        Vector3 baseDirection = transform.forward;

        // 각도 설정
        float[] angles = { 0f, 15f, -15f };

        // 각도에 따라 총알 생성
        foreach (float angle in angles)
        {
            // 방향 설정 (각도 회전 적용)
            Vector3 direction = Quaternion.Euler(0, angle, 0) * baseDirection;

            // 총알 생성
            GameObject bullet = Instantiate(bulletFactory, spawnPosition, Quaternion.Euler(0,angle,0));

            // 총알의 방향 설정
            bullet.GetComponent<Bullet>().dir = direction;

        }

    }
    void SGFireFIve()
    {
        Debug.Log("5SG");
        // 샷건 발사 (여러 발의 총알을 한 번에 발사)
        // 총알 생성 위치 설정
        Vector3 spawnPosition = transform.position;

        // 기본 방향 설정 (예: 오른쪽 방향)
        Vector3 baseDirection = transform.forward;

        // 각도 설정
        float[] angles = { -20f, -10f, 0f, 10f, 20f };

        // 각도에 따라 총알 생성
        foreach (float angle in angles)
        {
            // 방향 설정 (각도 회전 적용)
            Vector3 direction = Quaternion.Euler(0, angle, 0) * baseDirection;

            // 총알 생성
            GameObject bullet = Instantiate(bulletFactory, spawnPosition, Quaternion.LookRotation(direction));

            // 총알의 방향 설정
            bullet.GetComponent<Bullet>().dir = direction;

        }

    }
}
