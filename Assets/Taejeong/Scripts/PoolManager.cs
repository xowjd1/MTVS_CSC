using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    /*
    에너미와 아이템박스를 소환한다.
    에너미의 소환 주기는 2초
    아이템의 소환 주기는 10초

    아이템이 소환될 시간에는 에너미는 소환되지 않는다.
    보스 에너미가 소환되면 에너미와 아이템의 소환을 정지한다.

    */

    public float enemyTime = 2.0f;
    public float itemTime = 10.0f;
    float currentTime; //현재시간

    public GameObject enemyFactory;
    public GameObject itemFactory;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, 2f);  // "SpawnEnemy" 함수를 0초 후에 시작하고, 2초 간격으로 반복 호출
    }


    void SpawnEnemy()
    {
        Instantiate(enemyFactory, transform.position, Quaternion.identity);  // 적을 현재 스폰 포인트에서 소환
    }
}
