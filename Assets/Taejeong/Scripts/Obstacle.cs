using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float rotSpeed = 100f; // ȸ���ӵ�
    public GameObject[] obItems;


    // ������ �迭�� ���� �� Obstacle�� �θ��� Obstacle Item �� ������ ��
    // �Ź� �ٸ� �������� ���� �ʹ�.

    void Start()
    {
        foreach (GameObject item in obItems)
        {
            item.SetActive(false);
        }
        int rd = Random.Range(0, obItems.Length); // 0���� obItems.Length-1 ������ ������ �ε��� ����

        // ��� �������� ��Ȱ��ȭ
        for (int i = 0; i < obItems.Length; i++)
        {
            obItems[i].SetActive(false);
        }

        // �����ϰ� ���õ� �������� Ȱ��ȭ
        obItems[rd].SetActive(true);
    }

    void Update()
    {
        transform.Rotate(Vector3.right * rotSpeed * Time.deltaTime);


        
    }




    }
