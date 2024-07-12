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

    // ui ��ȭâ�� ����ǰ� �����̽��ٸ� ���� ������ ����ȴ�. > bool ó��
    // 1. ������ ���� , �÷��̾� �̵� �����ϵ���
    // 2, ���ʹ� ���� , ���ʹ� ����
    // 3. ���� ����, ���� ����
    // 4. ������ ���� , ������ ����
    // 5. ���� ������ ����, ����


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
        // �̵� ������ �����ٸ� ���⸦ �����Ѵ�.
        if (isMove)
        {
            // ����Ʈ ����

            // �⺻ ���⸦ ��ȯ�Ѵ�.
            Transform ngun = GameObject.Find("Player").transform.GetChild(0);


            if (ngun != null)
            {
                ngun.gameObject.SetActive(true);
                //���� ������ ���Դٸ�
                if (isAttack)
                {
                    // ���ʹ� ����
                    SpawnEnemy();

                    //���ʹ� ������ ������ ���ʹ̸� óġ�ߴٸ�
                    if (enemySpawn && isEnemyDead)
                    {
                        // ������ ����
                        SpawnItem();

                        // ������ ������ ������ �������� ȹ���ߴٸ�
                        if (itemSpawn && isGetItem)
                        {
                            SpawnStatItem();

                            // ���Ⱦ����� ������ ���Դٸ�
                            if (statItemSpawn)
                                {
                                        // ����ȭ������ ���ư��� �����

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

            // �� �� ���������� ǥ��
            hasSpawned = true;
        }
    }

   
    

}
