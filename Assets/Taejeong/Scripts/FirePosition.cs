using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePosition : MonoBehaviour
{
    public GameObject bulletFactory;
    public float bulletSpawnTime;

    void Start()
    {
        InvokeRepeating("Fire", 0f, bulletSpawnTime);  // "SpawnEnemy" �Լ��� 0�� �Ŀ� �����ϰ�, 2�� �������� �ݺ� ȣ��
    }


    void Fire()
    {
        Instantiate(bulletFactory, transform.position, Quaternion.identity);  // ���� ���� ���� ����Ʈ���� ��ȯ
    }
}
