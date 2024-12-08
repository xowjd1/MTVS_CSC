using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float rotSpeed = 100f; // 회전속도
    public GameObject[] obItems;


    // 아이템 배열을 만들어서 이 Obstacle의 부모인 Obstacle Item 이 스폰될 때
    // 매번 다른 아이템을 띄우고 싶다.

    void Start()
    {
        foreach (GameObject item in obItems)
        {
            item.SetActive(false);
        }
        int rd = Random.Range(0, obItems.Length); // 0부터 obItems.Length-1 사이의 랜덤한 인덱스 생성

        // 모든 아이템을 비활성화
        for (int i = 0; i < obItems.Length; i++)
        {
            obItems[i].SetActive(false);
        }

        // 랜덤하게 선택된 아이템을 활성화
        obItems[rd].SetActive(true);
    }

    void Update()
    {
        transform.Rotate(Vector3.right * rotSpeed * Time.deltaTime);


        
    }




    }
