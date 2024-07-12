using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class TutoSystem : MonoBehaviour
{
    float currentTime;
    bool hasSpawned = false;
    bool hasSpawnedE = false;
    bool hasSpawnedI = false;


    public bool isMove = false;
    public bool isAttack = false;
    public bool enemySpawn = false;
    public bool itemSpawn = false;
    public bool statItemSpawn = false;

    public bool isEnemyDead = false;
    public bool isGetItem = false;



    public GameObject tutoEnemy;
    public GameObject tutoItem;
    public GameObject[] itemManagers;

    public Vector3[] itemManagerPositions = {
        new Vector3(-4, 1.25f, 35), // x
        new Vector3(0, 1.25f, 35),  // y
        new Vector3(4, 1.25f, 35)   // z
    };

    // ui 대화창이 진행되고 스페이스바를 누를 때마다 진행된다. > bool 처리
    // 1. 움직임 설명 , 플레이어 이동 가능하도록
    // 2, 에너미 스폰 , 에너미 설명
    // 3. 공격 설명, 무기 스폰
    // 4. 아이템 스폰 , 아이템 설명
    // 5. 스텟 아이템 스폰, 설명


    void Update()
    {
        currentTime += Time.deltaTime;

        Tuto();

        if(hasSpawnedE)
        {
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");

            if(enemy == null)
            {
                isEnemyDead = true;
            }

        }
        if (hasSpawnedI)
        {
            GameObject item = GameObject.FindGameObjectWithTag("TutoBox");

            if (item == null)
            {
                isGetItem = true;
            }

        }


    }

 
  
    void Tuto()
    {
        // 이동 설명이 끝났다면 무기를 스폰한다.
        if (isMove)
        {
            // 이펙트 생성

            // 기본 무기를 소환한다.
            Transform ngun = GameObject.Find("Player").transform.GetChild(0);


            if (ngun != null)
            {
                ngun.gameObject.SetActive(true);
                //공격 설명이 나왔다면
                if (isAttack)
                {
                    // 에너미 스폰
                    SpawnEnemy();

                    //에너미 설명이 나오고 에너미를 처치했다면
                    if (enemySpawn && isEnemyDead)
                    {
                        // 아이템 스폰
                        SpawnItem();

                        // 아이템 설명이 나오고 아이템을 획득했다면
                        if (itemSpawn && isGetItem)
                        {
                            SpawnStatItem();

                            // 스탯아이템 설명이 나왔다면
                            if (statItemSpawn)
                                {
                                        // 시작화면으로 돌아가게 만들기

                                }
                            
                        }
                    }
                }
            }
            

        }   
        
       
    }

    void SpawnEnemy()
    {
        if(!hasSpawnedE)
        { 
        GameObject se = Instantiate(tutoEnemy);
            hasSpawnedE = true;
        }
        
    }

    void SpawnItem()
    {
        if(!hasSpawnedI)
        {
        GameObject si = Instantiate(tutoItem);
            hasSpawnedI = true;
        }
    }

    void SpawnStatItem()
    {
        if (!hasSpawned)
        {
            GameObject m1 = Instantiate(itemManagers[0]);
            m1.transform.position = itemManagerPositions[0];
            GameObject m2 = Instantiate(itemManagers[1]);
            m2.transform.position = itemManagerPositions[1];
            GameObject m3 = Instantiate(itemManagers[2]);
            m3.transform.position = itemManagerPositions[2];

            // 한 번 생성했음을 표시
            hasSpawned = true;
        }
    }

   
    

}
