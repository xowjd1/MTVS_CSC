using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    /*
     x초마다 스포너에서 소환되서 직선이동만 한다.
     특성 : 스피드, 체력
     체력이 0이 되면 파괴된다.

     카메라 뒤까지 이동하면 파괴.

     ========================
     체력 숫자ui로 앞면에 표시
     총알에 파괴되면 이펙트 생성되고 아이템이 플레이어에게 이동하고
     아이템과 플레이어가 접촉하면 이펙트와 함께 플레이어 강화

     */

    public float speed = 10f; // 속도
    public int itemHp; // 체력
    public int maxItemHp; // 아이템 최대체력
    Vector3 dir = Vector3.back; // 이동방향
    bool isHit = false; // 총알에 맞았는지 여부

    public GameObject Bullet;

    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();

        itemHp = maxItemHp; // 스폰될 때 체력은 최대체력으로 설정
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

        /*
         if(isHit)
         {
          itemHP = itemHP - Bullet의 데미지;
         }
          
          if(itemHP <= 0)
          이펙트 실행, 파괴한다.
          자식 오브젝트를 플레이어에게 날린다.
         */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            isHit = true;
        }
    }

    }
