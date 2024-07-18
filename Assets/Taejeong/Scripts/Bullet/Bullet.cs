using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameManager gameManager;
    public int bDamage; // 총알 데미지
    public FirePosition firePosition;
    public GameObject impactPrefab;

    bool isEnemy = false; // 에너미와 충돌했는지 여부
    bool isBox = false; // 아이템 박스와 충돌했는지 여부
    bool isLine = false; // 파괴라인과 충돌했는지 여부
    bool isBoss = false;


    public float speed; // 총알 속도
    public Vector3 dir = Vector3.forward; // 방향은 앞으로


    void Update()
    {
        // 총알 데미지는 GameManager의 인스턴스의 damage다 실시간 업데이트
        bDamage = GameManager.instance.damage;

        if (GameManager.instance.isShotGun || GameManager.instance.isShotGun5
             || GameManager.instance.isShotGunEnd)
        {
            //firePosition.isShotGun = true;
            
            speed = 3.5f;
            transform.position += dir * speed * Time.deltaTime;
                
            // 90도 돌려서 회전
            transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            bDamage = GameManager.instance.sgDamage;
            if(transform.position.z >= 15)
            {
                Destroy(gameObject);
            }    
        }

        //충돌했다면 총알을 파괴한다.
        if (isEnemy)
            Destroy(gameObject);
            
        if (isBox)
            Destroy(gameObject);

        if (isLine)
            Destroy(gameObject);

        if (isBoss)
            Destroy(gameObject);


    }

    private void OnTriggerEnter(Collider other)
    {
        // 닿은 태그가 Enemy 라면 ( 에너미와의 상호작용)
        if (other.tag == "Enemy")
        {
            isEnemy = true; // 에너미와 충돌했으니 true 전환               
            Instantiate(impactPrefab,transform.position,Quaternion.identity);
        }
        if (other.tag == "Boss")
        {
            isBoss = true;
            Instantiate(impactPrefab, transform.position, Quaternion.identity);
        }
        // 닿은 태그가 ItemBox 라면 ( 아이템 박스와의 상호작용)
        if (other.tag == "ItemBox")
        {
            isBox = true; // 아이템박스와 충돌했으니 true 전환
            Instantiate(impactPrefab, transform.position, Quaternion.identity);

        }
        // 닿은 태그가 BulletDestroyLine 라면 ( 일정거리 이상 넘어갔을 때 불렛 삭제 )
        if (other.tag == "BulletDestroyLine")
        {
            isLine = true; // 파괴라인과 충돌했으니 true 전환
         

        }

    }

}
