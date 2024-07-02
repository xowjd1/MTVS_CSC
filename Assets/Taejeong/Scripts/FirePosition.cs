using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePosition : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerHit player;
    public GameObject bulletFactory;
    public float bulletSpawnTime;
    // public float maxBulletSpawnTime = 0.4f;
    float currentTime;

    
    void OnEnable()
    {
        
    }

 
    void Start()
    {

        // InvokeRepeating("Fire", 0f, bulletSpawnTime);  // "SpawnEnemy" �Լ��� 0�� �Ŀ� �����ϰ�, 0.5f�� �������� �ݺ� ȣ��
        bulletSpawnTime = player.bsTime;
     

    }

    private void Update()
    {
        bulletSpawnTime = player.bsTime;
        currentTime += Time.deltaTime;

        if( currentTime >= bulletSpawnTime )
        {
            Fire();
            currentTime = 0;
        }
    }

    void Fire()
    {
        GameObject bullet =  Instantiate(bulletFactory, transform.position, Quaternion.identity);  // ���� ���� ���� ����Ʈ���� ��ȯ
        
    }
}
