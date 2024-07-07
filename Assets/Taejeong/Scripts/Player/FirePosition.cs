using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePosition : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerHit player;
    public GameObject bulletFactory;
    public float bulletSpawnTime; // �Ѿ� �߻� �ֱ� �ð�
    float currentTime;
    public bool isShotGun = false; // �����ΰ�
    public bool isShotGunFive = false; // 5�� �����ΰ�



    void Start()
    {
        // bulletSpawnTime �� �÷��̾��� bsTime �̴�.
        isShotGun = GameManager.instance.isShotGun;
        isShotGunFive = GameManager.instance.isShotGun5;
        bulletSpawnTime = player.bsTime;
    }

    private void Update()
    {
        // bulletSpawnTime �� �÷��̾��� bsTime �̴�. �ǽð� ������Ʈ
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
        // �Ѿ��� ���� ���� ����Ʈ���� ��ȯ
        GameObject bullet =  Instantiate(bulletFactory, transform.position, Quaternion.identity);  
    }

    void SGFire()
    {
        Debug.Log("SG");
        // ���� �߻� (���� ���� �Ѿ��� �� ���� �߻�)
        // �Ѿ� ���� ��ġ ����
        Vector3 spawnPosition = transform.position;

        // �⺻ ���� ���� (��: ������ ����)
        Vector3 baseDirection = transform.forward;

        // ���� ����
        float[] angles = { 0f, 15f, -15f };

        // ������ ���� �Ѿ� ����
        foreach (float angle in angles)
        {
            // ���� ���� (���� ȸ�� ����)
            Vector3 direction = Quaternion.Euler(0, angle, 0) * baseDirection;

            // �Ѿ� ����
            GameObject bullet = Instantiate(bulletFactory, spawnPosition, Quaternion.Euler(0,angle,0));

            // �Ѿ��� ���� ����
            bullet.GetComponent<Bullet>().dir = direction;

        }

    }
    void SGFireFIve()
    {
        Debug.Log("5SG");
        // ���� �߻� (���� ���� �Ѿ��� �� ���� �߻�)
        // �Ѿ� ���� ��ġ ����
        Vector3 spawnPosition = transform.position;

        // �⺻ ���� ���� (��: ������ ����)
        Vector3 baseDirection = transform.forward;

        // ���� ����
        float[] angles = { -20f, -10f, 0f, 10f, 20f };

        // ������ ���� �Ѿ� ����
        foreach (float angle in angles)
        {
            // ���� ���� (���� ȸ�� ����)
            Vector3 direction = Quaternion.Euler(0, angle, 0) * baseDirection;

            // �Ѿ� ����
            GameObject bullet = Instantiate(bulletFactory, spawnPosition, Quaternion.LookRotation(direction));

            // �Ѿ��� ���� ����
            bullet.GetComponent<Bullet>().dir = direction;

        }

    }
}
