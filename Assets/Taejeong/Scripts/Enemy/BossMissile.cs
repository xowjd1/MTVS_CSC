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

        //충돌했다면 총알을 파괴한다.
        if (isPlayer)
            Destroy(gameObject);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        // 닿은 태그가 Enemy 라면 ( 에너미와의 상호작용)
        if (other.tag == "Player")
        {
            isPlayer = true; // 에너미와 충돌했으니 true 전환
            Instantiate(impactPrefab, transform.position, Quaternion.identity);
        }
        

    }
}
