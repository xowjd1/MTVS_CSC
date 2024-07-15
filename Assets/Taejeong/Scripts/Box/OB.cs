using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


public class OB : MonoBehaviour
{

    GameManager gameManager;
    Bullet bullet;
    MGBullet mgBullet;
    DroneBullet dBullet;
    Missile missile;

   
    public int obHP;
    public int maxOBHP;
    public int boxDamage = 1; // 박스와 충돌할때 플레이어가 받을 데미지

    bool isHit = false; // 총알에 맞았는지 여부
    bool isDroneHit = false; // 드론총알에 맞았는지 여부
    bool isMissileHit = false; // 미사일에 맞았는지 여부
    bool isMGBulletHit = false; // 머신건에 맞았는지 여부


    void OnEnable()
    {
        maxOBHP = (int)(GameManager.instance.time * Random.Range(200, 250));
        obHP = maxOBHP;

    }



    void Update()
    {
       
        if (isHit)
        {
            obHP -= bullet.bDamage;

            isHit = false; // 데미지를 한번만 받아야하니까 false처리
            //itemHP 가 0 이하가 되면
            if (obHP <= 0)
            {
                OBHPMinus(); // 이벤트(함수)를 불러온다.
            }
        }
        if (isMGBulletHit)
        {
            obHP -= mgBullet.mgDamage;
            isMGBulletHit = false; // 데미지를 한번만 받아야하니까 false처리
            //itemHP 가 0 이하가 되면
            if (obHP <= 0)
            {
                OBHPMinus(); // 이벤트(함수)를 불러온다.
            }
        }
        if (isDroneHit)
        {
            obHP -= dBullet.damage;
            isDroneHit = false; // 데미지를 한번만 받아야하니까 false처리
            //itemHP 가 0 이하가 되면
            if (obHP <= 0)
            {
                OBHPMinus(); // 이벤트(함수)를 불러온다.
            }
        }
        if (isMissileHit)
        {
            obHP -= missile.damage;
            isMissileHit = false; // 데미지를 한번만 받아야하니까 false처리
            //itemHP 가 0 이하가 되면
            if (obHP <= 0)
            {
                OBHPMinus(); // 이벤트(함수)를 불러온다.
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
    void OBHPMinus()
    {
        //이펙트 실행, 파괴한다.
        //자식 오브젝트 분리.
        Destroy(gameObject);

    }
    IEnumerator ScaleBox()
    {

        Vector3 originalParentScale = transform.localScale;


        transform.localScale = originalParentScale * 0.9f;

        yield return new WaitForSeconds(0.02f);

        transform.localScale = originalParentScale;
    }


}
