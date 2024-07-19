using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMissile : MonoBehaviour
{
    public int damage;
    public float speed = 20;
   
    bool isPlayer = false;
    public GameObject impactPrefab;

    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;

        //�浹�ߴٸ� �Ѿ��� �ı��Ѵ�.
        if (isPlayer)
            Destroy(gameObject);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        // ���� �±װ� Enemy ��� ( ���ʹ̿��� ��ȣ�ۿ�)
        if (other.tag == "Player")
        {
            isPlayer = true; // ���ʹ̿� �浹������ true ��ȯ
            Instantiate(impactPrefab, transform.position, Quaternion.identity);
        }
        

    }
}
