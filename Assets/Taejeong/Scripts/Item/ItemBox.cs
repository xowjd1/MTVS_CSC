using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    /*
     x초마다 스포너에서 소환되서 직선이동만 한다.
     특성 : 스피드, 체력
     
     총알과 충돌할 때
     itemHp = itemHp - bullet.damage;
     만약 itemHp <= 0 이라면
     transform.DetachChildren() 부모-자식 관계를 끊고 자식 오브젝트들을 독립
     itemBox는 파괴하고 남은 자식오브젝트는 플레이어를 타겟팅하여 이동
     플레이어와 접촉하면 이펙트를 생성하고 능력치를 부여한다.

     카메라 뒤까지 이동하면 파괴.

     ========================
     체력 숫자ui로 앞면에 표시
     총알에 파괴되면 이펙트 생성되고 아이템이 플레이어에게 이동하고
     아이템과 플레이어가 접촉하면 이펙트와 함께 플레이어 강화

     */

    public float speed = 10f; // 속도
    public int itemHP; // 체력
    public int maxItemHP; // 아이템 최대체력
    public int boxDamage =1; // 박스와 충돌할때 플레이어가 받을 데미지
    Vector3 dir = Vector3.back; // 이동방향
    bool isHit = false; // 총알에 맞았는지 여부
    bool isDroneHit = false; // 드론총알에 맞았는지 여부


    // public GameObject Bullet;

    Bullet bullet;
    DroneBullet dBullet;
    Rigidbody rigid;

    void OnEnable()
    { 
       itemHP = maxItemHP; // 스폰될 때 체력은 최대체력으로 설정

    }

    void Update()
    {
       transform.position += dir * speed * Time.deltaTime;

        //카메라 뒤까지 이동하면 파괴.
        if (transform.position.z <= -5.0f)
        {
            Destroy(gameObject);
            Debug.Log("아이템 박스 카메라 뒤로 이동 파괴.");
        }

       
        if (isHit)
         {
          itemHP -= bullet.bDamage;
            isHit = false; // 데미지를 한번만 받아야하니까 false처리
            //itemHP 가 0 이하가 되면
            if (itemHP <= 0)
            {
                ItemHPMinus(); // 이벤트(함수)를 불러온다.
            }
         }
        if (isDroneHit)
        {
            itemHP -= dBullet.damage;
            isDroneHit = false; // 데미지를 한번만 받아야하니까 false처리
            //itemHP 가 0 이하가 되면
            if (itemHP <= 0)
            {
                ItemHPMinus(); // 이벤트(함수)를 불러온다.
            }
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            // 충돌한 총알의 Bullet 컴포넌트를 가져옴
            bullet = other.GetComponent<Bullet>(); 
            if (bullet != null)
            {
                isHit = true;
                Debug.Log("Bullet Hit");
            }
        }
        if (other.CompareTag("DroneBullet"))
        {
            // 충돌한 총알의 Bullet 컴포넌트를 가져옴
            dBullet = other.GetComponent<DroneBullet>();
            if (dBullet != null)
            {
                isDroneHit = true;
                Debug.Log("DBullet Hit");
            }
        }
   
    }


    void ItemHPMinus()
    {
        //이펙트 실행, 파괴한다.
        //자식 오브젝트 분리.
        transform.DetachChildren();
        Destroy(gameObject);

    }
}
