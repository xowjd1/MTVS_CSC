using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBullet : MonoBehaviour
{
    public int damage;
    public float speed;
    bool isEnemy = false; // 에너미와 충돌했는지 여부
    bool isBox = false; // 아이템 박스와 충돌했는지 여부
    bool isLine = false; // 파괴라인과 충돌했는지 여부

    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;

        //충돌했다면 총알을 파괴한다.
        if (isEnemy)
            Destroy(gameObject);
        if (isBox)
            Destroy(gameObject);
        if (isLine)
            Destroy(gameObject);
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
