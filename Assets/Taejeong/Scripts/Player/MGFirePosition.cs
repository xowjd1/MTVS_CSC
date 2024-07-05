using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MGFirePosition : MonoBehaviour
{
    // ���� �Ѿ� �߻�� ������
    // ���� �����ǿ� �������� �ο��Ѵ�.

    public GameManager gameManager;
    public PlayerHit player;
    public GameObject bulletFactory;
    public float bulletSpawnTime; // �Ѿ� �߻� �ֱ� �ð�
    float currentTime;


    void Start()
    {
        // bulletSpawnTime �� �÷��̾��� bsTime �̴�.
        bulletSpawnTime = player.mgbsTime;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= bulletSpawnTime)
        {
            Fire();
            currentTime = 0;
        }
    }



    private void Fire()
    {
        Vector3 randomOffset = new Vector3(Random.Range(-0.15f, 0.15f), Random.Range(-0.15f, 0.15f), Random.Range(-0.15f, 0.15f));
        Vector3 spawnPosition = transform.position + randomOffset;

        GameObject bullet = Instantiate(bulletFactory, spawnPosition, Quaternion.identity);
    }


}
