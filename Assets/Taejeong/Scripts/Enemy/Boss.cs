using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    MGBullet mgBullet;
    DroneBullet dBullet;
    Missile missile;
    public GameManager gameManager;
    public Rigidbody gameOverDummy; // 게임오버용 더미
    public Rigidbody target;

    public float speed = 5;
    public int bossHP;
    public int damage = 5; 

    bool isDroneHit = false; // 드론총알에 맞았는지 여부
    bool isMissileHit = false; // 미사일에 맞았는지 여부
    bool isMGBulletHit = false; // 머신건에 맞았는지 여부

    void Start()
    {
        
    }

    void Update()
    {
        if (target == null || GameManager.instance.player == null)
        {
            target = gameOverDummy;
        }
        else
        {
            target = GameManager.instance.player.GetComponent<Rigidbody>();
        }

        // 따라가기
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;

        if (isMGBulletHit)
        {
            bossHP -= mgBullet.mgDamage;
            isMGBulletHit = false; // 데미지를 한번만 받아야하니까 false처리
            //itemHP 가 0 이하가 되면
            if (bossHP <= 0)
            {
                BossHPMinus(); // 이벤트(함수)를 불러온다.
            }
        }
        if (isDroneHit)
        {
            bossHP -= dBullet.damage;
            isDroneHit = false; // 데미지를 한번만 받아야하니까 false처리
            //itemHP 가 0 이하가 되면
            if (bossHP <= 0)
            {
                BossHPMinus(); // 이벤트(함수)를 불러온다.
            }
        }
        if (isMissileHit)
        {
            bossHP -= missile.damage;
            isMissileHit = false; // 데미지를 한번만 받아야하니까 false처리
            //itemHP 가 0 이하가 되면
            if (bossHP <= 0)
            {
                BossHPMinus(); // 이벤트(함수)를 불러온다.
            }
        }



    }
    void OnTriggerEnter(Collider other)
    {
        //기본 총알은 스크립트 머신에 되어있고
        if (other.CompareTag("DroneBullet"))
        {

            dBullet = other.GetComponent<DroneBullet>();
            if (dBullet != null)
            {
                isDroneHit = true;

            }
        }
        if (other.CompareTag("MGBullet"))
        {

            mgBullet = other.GetComponent<MGBullet>();
            if (mgBullet != null)
            {
                isMGBulletHit = true;
            }

        }
        if (other.CompareTag("Missile"))
        {

            missile = other.GetComponent<Missile>();
            if (missile != null)
            {
                isMissileHit = true;

            }
        }
    }
    void BossHPMinus()
    {
        Destroy(gameObject);
    }

}
