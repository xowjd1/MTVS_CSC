using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Bullet bullet;
    MGBullet mgBullet;
    DroneBullet dBullet;
    Missile missile;
    public GameManager gameManager;
    public Rigidbody gameOverDummy; // 게임오버용 더미
    public Rigidbody target;

    public float speed = 5;
    public int bossHP;
    public int damage = 5;

    bool isHit = false; // 총알에 맞았는지 여부
    public bool isBossLose = false;


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

        // 보스의 z위치가 60 40 20 일때 speed 를 0으로 만들고
        // 미사일 두발을 발사한다.
        // 미사일을 발사했다면 다시 speed를 5 로 바꾼다.
        // 보스의 z위치가 플레이어 앞일때
        // 자폭함수를 실행한다.



        if (isHit)
        {
            bossHP -= bullet.bDamage;

            isHit = false; // 데미지를 한번만 받아야하니까 false처리
            //itemHP 가 0 이하가 되면
            if (bossHP <= 0)
            {
                BossHPMinus(); // 이벤트(함수)를 불러온다.
            }
        }
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
        if (other.CompareTag("Bullet"))
        {
            // 충돌한 총알의 Bullet 컴포넌트를 가져옴
            bullet = other.GetComponent<Bullet>();
            if (bullet != null)
            {
                isHit = true;
            }
        }
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
        isBossLose = true;
        Destroy(gameObject);
    }

    //보스 자폭 공격
    void BossLastAttack()
    {

        // 자폭
        Destroy(gameObject);
        // 공격

    }

}
