using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    MGBullet mgBullet;
    DroneBullet dBullet;
    Missile missile;
    Bullet bullet;
    public GameManager gameManager;
    public Rigidbody gameOverDummy; // 게임오버용 더미
    public Rigidbody target;

    public int damage = 1;// 에너미의 데미지
    public int enemyHP = 1;
    public float speed = 5;

    bool isBulletHit = false;
    bool isDroneHit = false; // 드론총알에 맞았는지 여부
    bool isMissileHit = false; // 미사일에 맞았는지 여부
    bool isMGBulletHit = false; // 머신건에 맞았는지 여부
    bool isLess;
    public bool isTuto = false;




    void Start()
    {
        int i = Random.Range(0, 10);
        if (i < 5)
            isLess = true;
        else
            isLess = false;
    }


    void Update()
    {
        
        if (isLess == true)
        {
            // 직선이동
            transform.position += Vector3.back * speed * Time.deltaTime;
            if(transform.position.z <= 20)
            {
                isLess = false;
            }
        }
        else
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
            
        }
        if (isBulletHit)
        {
            enemyHP --;
            isBulletHit = false; // 데미지를 한번만 받아야하니까 false처리
            //itemHP 가 0 이하가 되면
            if (enemyHP <= 0)
            {
                EnemyHPMinus(); // 이벤트(함수)를 불러온다.
            }
        }
        if (isMGBulletHit)
        {
            enemyHP -= mgBullet.mgDamage;
            isMGBulletHit = false; // 데미지를 한번만 받아야하니까 false처리
            //itemHP 가 0 이하가 되면
            if (enemyHP <= 0)
            {
                EnemyHPMinus(); // 이벤트(함수)를 불러온다.
            }
        }
        if (isDroneHit)
        {
            enemyHP -= dBullet.damage;
            isDroneHit = false; // 데미지를 한번만 받아야하니까 false처리
            //itemHP 가 0 이하가 되면
            if (enemyHP <= 0)
            {
                EnemyHPMinus(); // 이벤트(함수)를 불러온다.
            }
        }
        if (isMissileHit)
        {
            enemyHP -= missile.damage;
            isMissileHit = false; // 데미지를 한번만 받아야하니까 false처리
            //itemHP 가 0 이하가 되면
            if (enemyHP <= 0)
            {
                EnemyHPMinus(); // 이벤트(함수)를 불러온다.
            }
        }
    }

  
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Bullet"))
        {

            bullet = other.GetComponent<Bullet>();
            if (bullet != null)
            {
                isBulletHit = true;

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
    void EnemyHPMinus()
    {
        Destroy(gameObject);
    }
}
