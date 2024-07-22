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
    public Rigidbody gameOverDummy; // ���ӿ����� ����
    public Rigidbody target;

    public int damage = 1;// ���ʹ��� ������
    public int enemyHP = 1;
    public float speed = 5;

    bool isBulletHit = false;
    bool isDroneHit = false; // ����Ѿ˿� �¾Ҵ��� ����
    bool isMissileHit = false; // �̻��Ͽ� �¾Ҵ��� ����
    bool isMGBulletHit = false; // �ӽŰǿ� �¾Ҵ��� ����
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
            // �����̵�
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

                // ���󰡱�
                Vector3 dir = target.transform.position - transform.position;
                dir.Normalize();
                transform.position += dir * speed * Time.deltaTime;
            
        }
        if (isBulletHit)
        {
            enemyHP --;
            isBulletHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��
            //itemHP �� 0 ���ϰ� �Ǹ�
            if (enemyHP <= 0)
            {
                EnemyHPMinus(); // �̺�Ʈ(�Լ�)�� �ҷ��´�.
            }
        }
        if (isMGBulletHit)
        {
            enemyHP -= mgBullet.mgDamage;
            isMGBulletHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��
            //itemHP �� 0 ���ϰ� �Ǹ�
            if (enemyHP <= 0)
            {
                EnemyHPMinus(); // �̺�Ʈ(�Լ�)�� �ҷ��´�.
            }
        }
        if (isDroneHit)
        {
            enemyHP -= dBullet.damage;
            isDroneHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��
            //itemHP �� 0 ���ϰ� �Ǹ�
            if (enemyHP <= 0)
            {
                EnemyHPMinus(); // �̺�Ʈ(�Լ�)�� �ҷ��´�.
            }
        }
        if (isMissileHit)
        {
            enemyHP -= missile.damage;
            isMissileHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��
            //itemHP �� 0 ���ϰ� �Ǹ�
            if (enemyHP <= 0)
            {
                EnemyHPMinus(); // �̺�Ʈ(�Լ�)�� �ҷ��´�.
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
