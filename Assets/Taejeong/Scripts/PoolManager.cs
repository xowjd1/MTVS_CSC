using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    /*
    ���ʹ̿� �����۹ڽ��� ��ȯ�Ѵ�.
    ���ʹ��� ��ȯ �ֱ�� 2��
    �������� ��ȯ �ֱ�� 10��

    �������� ��ȯ�� �ð����� ���ʹ̴� ��ȯ���� �ʴ´�.
    ���� ���ʹ̰� ��ȯ�Ǹ� ���ʹ̿� �������� ��ȯ�� �����Ѵ�.

    */

    public float enemyTime = 2.0f;
    public float itemTime = 10.0f;
    float currentTime; //����ð�

    public GameObject enemyFactory;
    public GameObject itemFactory;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, 2f);  // "SpawnEnemy" �Լ��� 0�� �Ŀ� �����ϰ�, 2�� �������� �ݺ� ȣ��
    }


    void SpawnEnemy()
    {
        Instantiate(enemyFactory, transform.position, Quaternion.identity);  // ���� ���� ���� ����Ʈ���� ��ȯ
    }
}
