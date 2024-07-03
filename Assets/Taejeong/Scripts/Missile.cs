using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Missile : MonoBehaviour
{
    // 각 미사일에 대해 가장 가까운 타겟 찾기
    public float speed;
    public float radius = 0f;
    public LayerMask layer;
    public Collider[] colliders;
    public Collider short_enemy;

    bool isEnemy = false; // 에너미와 충돌했는지 여부
    bool isBox = false; // 아이템 박스와 충돌했는지 여부
    bool isLine = false; // 파괴라인과 충돌했는지 여부

    void Start()
    {

    }

    void Update()
    {
        colliders = Physics.OverlapSphere(transform.position, radius, layer);

        if (colliders.Length == 0)
            return;

        if (colliders.Length > 0)
        {
            float short_distance = Vector3.Distance(transform.position, colliders[0].transform.position);
            foreach (Collider col in colliders)
            {
                float short_distance2 = Vector3.Distance(transform.position, col.transform.position);
                if (short_distance > short_distance2)
                {
                    short_distance = short_distance2;
                    short_enemy = col;
                }
            }

        }
        if (colliders.Length >0 && short_enemy != null)
        {
            transform.position += (short_enemy.transform.position - transform.position).normalized * speed * Time.deltaTime;
        }
        //충돌했다면 총알을 파괴한다.
        if (isEnemy)
            Destroy(gameObject);
        if (isBox)
            Destroy(gameObject);
        if (isLine)
            Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 닿은 태그가 Enemy 라면 ( 에너미와의 상호작용)
        if (other.tag == "Enemy")
        {
            isEnemy = true; // 에너미와 충돌했으니 true 전환
                            // Debug.Log("불렛 - 에너미 충돌"); // 확인용 콘솔메세지 출력
        }
        // 닿은 태그가 ItemBox 라면 ( 아이템 박스와의 상호작용)
        if (other.tag == "ItemBox")
        {
            isBox = true; // 아이템박스와 충돌했으니 true 전환
                          //  Debug.Log("불렛 - 아이템박스 충돌"); // 확인용 콘솔메세지 출력

        }
        // 닿은 태그가 BulletDestroyLine 라면 ( 일정거리 이상 넘어갔을 때 불렛 삭제 )
        if (other.tag == "BulletDestroyLine")
        {
            isLine = true; // 파괴라인과 충돌했으니 true 전환
                           //  Debug.Log("불렛 - 파괴라인 충돌"); // 확인용 콘솔메세지 출력

        }

    }

}
