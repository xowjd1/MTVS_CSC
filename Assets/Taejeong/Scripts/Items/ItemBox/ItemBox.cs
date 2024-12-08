using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    /*
     x초마다 스포너에서 소환되서 직선이동만 한다.
     특성 : 스피드, 체력
     
     총알과 충돌할 때
     itemHp = itemHp - bullet.damage;
     만약 itemHp <= 0 이라면
     itemBox는 파괴
     플레이어와 접촉하면 이펙트를 생성하고 능력치를 부여한다.

     총알에 피격시 스케일값이 변했다가 돌아온다.


     카메라 뒤까지 이동하면 파괴.

     ========================
     체력 숫자ui로 앞면에 표시
     총알에 파괴되면 이펙트 생성되고 아이템이 플레이어에게 이동하고
     아이템과 플레이어가 접촉하면 이펙트와 함께 플레이어 강화

     */

   // public float speed = 10f; // 속도
    public int itemHP; // 체력
    public int maxItemHP; // 아이템 최대체력
    public int boxDamage =1; // 박스와 충돌할때 플레이어가 받을 데미지
    Vector3 dir = Vector3.back; // 이동방향
    bool isHit = false; // 총알에 맞았는지 여부
    bool isDroneHit = false; // 드론총알에 맞았는지 여부
    bool isMissileHit = false; // 미사일에 맞았는지 여부
    bool isMGBulletHit = false; // 머신건에 맞았는지 여부
   public bool isTutorial = false; // 튜토리얼 전용 인지
  

    

    // public GameObject Bullet;

    Bullet bullet;
    MGBullet mgBullet;
    DroneBullet dBullet;
    Missile missile;

    void OnEnable()
    {

        if (isTutorial) // 튜토리얼 전용이라면 체력을 50으로 만든다.
            itemHP = 50;

        else // 튜토리얼이 아니라면 게임진행시간 * 랜덤값으로 체력값을 정해준다.
        {
            maxItemHP = (int)(GameManager.instance.time * Random.Range(GameManager.instance.randomMin, GameManager.instance.randomMax) + Random.Range(80, 120));
            itemHP = maxItemHP;
        }
      

    }

    void Update()
    {
     
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
        if (isMGBulletHit)
        {
            itemHP -= mgBullet.mgDamage;
            isMGBulletHit = false; // 데미지를 한번만 받아야하니까 false처리
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
        if (isMissileHit)
        {
            itemHP -= missile.damage;
            isMissileHit = false; // 데미지를 한번만 받아야하니까 false처리
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
                StartCoroutine(ScaleBox());
                isHit = true;
                Debug.Log("Bullet Hit");
            }
        }
        if (other.CompareTag("MGBullet"))
        {
            // 충돌한 총알의 Bullet 컴포넌트를 가져옴
            mgBullet = other.GetComponent<MGBullet>();
            if (mgBullet != null)
            {
                StartCoroutine(ScaleBox());
                isMGBulletHit = true;
                Debug.Log("Bullet Hit");
            }
        }
        if (other.CompareTag("DroneBullet"))
        {
            // 충돌한 총알의 Bullet 컴포넌트를 가져옴
            dBullet = other.GetComponent<DroneBullet>();
            if (dBullet != null)
            {
                StartCoroutine(ScaleBox());
                isDroneHit = true;
                Debug.Log("DBullet Hit");
            }
        }
        if (other.CompareTag("Missile"))
        {
            // 충돌한 총알의 Bullet 컴포넌트를 가져옴
            missile = other.GetComponent<Missile>();
            if (missile != null)
            {
                StartCoroutine(ScaleBox());
                isMissileHit = true;
                Debug.Log("Missile Hit");
            }
        }

    }


    void ItemHPMinus()
    {
        //이펙트 실행, 파괴한다.
        Destroy(gameObject);

    }
    // 피격시 스케일값 조정
    IEnumerator ScaleBox()
    {

        Vector3 originalParentScale = transform.localScale;


        transform.localScale = originalParentScale * 0.9f;

        yield return new WaitForSeconds(0.02f);

        transform.localScale = originalParentScale;
    }


}
