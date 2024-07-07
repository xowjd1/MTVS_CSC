using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    MGBullet mgBullet;
    DroneBullet dBullet;
    Missile missile;
    public GameManager gameManager;
    public Rigidbody gameOverDummy; // ���ӿ����� ����
    public Rigidbody target;

    public float speed = 5;
    public int bossHP;
    public int damage = 5; 

    bool isDroneHit = false; // ����Ѿ˿� �¾Ҵ��� ����
    bool isMissileHit = false; // �̻��Ͽ� �¾Ҵ��� ����
    bool isMGBulletHit = false; // �ӽŰǿ� �¾Ҵ��� ����

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

        // ���󰡱�
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;

        if (isMGBulletHit)
        {
            bossHP -= mgBullet.mgDamage;
            isMGBulletHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��
            //itemHP �� 0 ���ϰ� �Ǹ�
            if (bossHP <= 0)
            {
                BossHPMinus(); // �̺�Ʈ(�Լ�)�� �ҷ��´�.
            }
        }
        if (isDroneHit)
        {
            bossHP -= dBullet.damage;
            isDroneHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��
            //itemHP �� 0 ���ϰ� �Ǹ�
            if (bossHP <= 0)
            {
                BossHPMinus(); // �̺�Ʈ(�Լ�)�� �ҷ��´�.
            }
        }
        if (isMissileHit)
        {
            bossHP -= missile.damage;
            isMissileHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��
            //itemHP �� 0 ���ϰ� �Ǹ�
            if (bossHP <= 0)
            {
                BossHPMinus(); // �̺�Ʈ(�Լ�)�� �ҷ��´�.
            }
        }



    }
    void OnTriggerEnter(Collider other)
    {
        //�⺻ �Ѿ��� ��ũ��Ʈ �ӽſ� �Ǿ��ְ�
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
