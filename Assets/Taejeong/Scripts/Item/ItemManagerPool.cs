using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManagerPool : MonoBehaviour
{
    /*
     *  아이템 매니저 123을 x y z 세 위치에 랜덤하게 배치하고 싶다.
     *  1 2 3 , 1 3 2 , 2 1 3 , 2 3 1 , 3 1 2 , 3 2 1 을 16.6퍼센트의 확률로 배치한다
     *  
     */
    public Vector3[] itemManagerPositions = {
        new Vector3(-5, 1.25f, 50), // x
        new Vector3(0, 1.25f, 50),  // y
        new Vector3(5, 1.25f, 50)   // z
    };

    public GameObject[] itemManagers;
    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");

        if (player != null)
        {
            Debug.Log("Player found: " + player.name);

            if (itemManagers.Length != 3)
            {
                Debug.LogError("There must be exactly 3 item managers.");
                return;
            }

            int random = Random.Range(0, 6);
            Debug.Log("Random value: " + random);

            if (random == 0)
            {
                // Manager 1,2,3 순서
                GameObject m1 = Instantiate(itemManagers[0]);
                m1.transform.position = itemManagerPositions[0];
                GameObject m2 = Instantiate(itemManagers[1]);
                m2.transform.position = itemManagerPositions[1];
                GameObject m3 = Instantiate(itemManagers[2]);
                m3.transform.position = itemManagerPositions[2];


            }
            else if (random == 1)
            {
                // Manager 1,3,2 순서
                GameObject m1 = Instantiate(itemManagers[0]);
                m1.transform.position = itemManagerPositions[0];
                GameObject m2 = Instantiate(itemManagers[1]);
                m2.transform.position = itemManagerPositions[2];
                GameObject m3 = Instantiate(itemManagers[2]);
                m3.transform.position = itemManagerPositions[1];
            }
            else if (random == 2)
            {
                // Manager 2,1,3 순서
                GameObject m1 = Instantiate(itemManagers[0]);
                m1.transform.position = itemManagerPositions[1];
                GameObject m2 = Instantiate(itemManagers[1]);
                m2.transform.position = itemManagerPositions[0];
                GameObject m3 = Instantiate(itemManagers[2]);
                m3.transform.position = itemManagerPositions[2];
            }
            else if (random == 3)
            {
                // Manager 2,3,1 순서
                GameObject m1 = Instantiate(itemManagers[0]);
                m1.transform.position = itemManagerPositions[1];
                GameObject m2 = Instantiate(itemManagers[1]);
                m2.transform.position = itemManagerPositions[2];
                GameObject m3 = Instantiate(itemManagers[2]);
                m3.transform.position = itemManagerPositions[0];
            }
            else if (random == 4)
            {
                // Manager 3,1,2 순서
                GameObject m1 = Instantiate(itemManagers[0]);
                m1.transform.position = itemManagerPositions[2];
                GameObject m2 = Instantiate(itemManagers[1]);
                m2.transform.position = itemManagerPositions[0];
                GameObject m3 = Instantiate(itemManagers[2]);
                m3.transform.position = itemManagerPositions[1];
            }
            else
            {
                // Manager 3,2,1 순서
                GameObject m1 = Instantiate(itemManagers[0]);
                m1.transform.position = itemManagerPositions[2];
                GameObject m2 = Instantiate(itemManagers[1]);
                m2.transform.position = itemManagerPositions[1];
                GameObject m3 = Instantiate(itemManagers[2]);
                m3.transform.position = itemManagerPositions[0];
            }

            // Log positions
            Debug.Log("ItemManager 0 position: " + itemManagers[0].transform.position);
            Debug.Log("ItemManager 1 position: " + itemManagers[1].transform.position);
            Debug.Log("ItemManager 2 position: " + itemManagers[2].transform.position);
        }
        else
        {
            Debug.LogError("Player not found.");
        }
    }
}
