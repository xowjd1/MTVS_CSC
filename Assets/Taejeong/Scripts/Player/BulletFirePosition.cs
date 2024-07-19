using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFirePosition : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject muzzleSpawn;
    public float bulletSpawnTime; // �Ѿ� �߻� �ֱ� �ð�
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
        // �Ѿ��� ���� ���� ����Ʈ���� ��ȯ
        GameObject bullet = Instantiate(bulletFactory, transform.position, Quaternion.identity);
        GameObject muzzle = Instantiate(muzzleSpawn, transform.position, Quaternion.identity);
    }
}
