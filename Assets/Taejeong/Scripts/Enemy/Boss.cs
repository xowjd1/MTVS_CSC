using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Bullet bullet;
    MGBullet mgBullet;
    DroneBullet dBullet;
    Missile missile;
    BossStop bossStop;
    public GameObject explosion;
    public Collider suicideATK;
    public GameManager gameManager;
    public Rigidbody gameOverDummy; // ���ӿ����� ����
    public Rigidbody target;
    public GameObject bossMissileFactory;

    public float speed = 5;
   // public int bossHP;
    public int damage = 5;

    bool isHit = false; // �Ѿ˿� �¾Ҵ��� ����
    bool isFire = false;


    bool isDroneHit = false; // ����Ѿ˿� �¾Ҵ��� ����
    bool isMissileHit = false; // �̻��Ͽ� �¾Ҵ��� ����
    bool isMGBulletHit = false; // �ӽŰǿ� �¾Ҵ��� ����
    bool isBossStop = false;

    void Start()
    {
        GameManager.instance.boss = this;
        suicideATK.gameObject.SetActive(false);


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

        if (transform.position.z <= 5)
        {
            BossSuicideAttack();
        }
        // ������ z��ġ�� 60 40 20 �϶� speed �� 0���� �����
        // �̻��� �ι��� �߻��Ѵ�.
        // �̻����� �߻��ߴٸ� �ٽ� speed�� 5 �� �ٲ۴�.
        // ������ z��ġ�� �÷��̾� ���϶�
        // �����Լ��� �����Ѵ�.



        if (isHit)
        {
            GameManager.instance.bossHP -= bullet.bDamage;

            isHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��
            //itemHP �� 0 ���ϰ� �Ǹ�
            if (GameManager.instance.bossHP <= 0)
            {
                BossHPMinus(); // �̺�Ʈ(�Լ�)�� �ҷ��´�.
            }
        }
        if (isMGBulletHit)
        {
            GameManager.instance.bossHP -= mgBullet.mgDamage;
            isMGBulletHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��
            //itemHP �� 0 ���ϰ� �Ǹ�
            if (GameManager.instance.bossHP <= 0)
            {
                BossHPMinus(); // �̺�Ʈ(�Լ�)�� �ҷ��´�.
            }
        }
        if (isDroneHit)
        {
            GameManager.instance.bossHP -= dBullet.damage;
            isDroneHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��
            //itemHP �� 0 ���ϰ� �Ǹ�
            if (GameManager.instance.bossHP <= 0)
            {
                BossHPMinus(); // �̺�Ʈ(�Լ�)�� �ҷ��´�.
            }
        }
        if (isMissileHit)
        {
            GameManager.instance.bossHP -= missile.damage;
            isMissileHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��
            //itemHP �� 0 ���ϰ� �Ǹ�
            if (GameManager.instance.bossHP <= 0)
            {
                BossHPMinus(); // �̺�Ʈ(�Լ�)�� �ҷ��´�.
            }
        }
        if(isBossStop)
        {
            isFire = true;
            FIre();
            isBossStop = false;
           StartCoroutine(BossStopAndAttack());
        }    




    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            // �浹�� �Ѿ��� Bullet ������Ʈ�� ������
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
        if (other.CompareTag("BossStop"))
        {

            bossStop = other.GetComponent<BossStop>();
            if (bossStop != null)
            {
                isBossStop = true;

            }
        }
    }

    void BossHPMinus()
    {
        GameManager.instance.isGameWin = true;
        GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void FIre()
    {
        if(isFire)
        {
            
            Vector3 missilePos1 = transform.position + new Vector3(-1, 1, -4);
            Vector3 missilePos2 = transform.position + new Vector3(1, 1, -4);

            GameObject bossM1 = Instantiate(bossMissileFactory, missilePos1, Quaternion.identity);
            GameObject bossM2 = Instantiate(bossMissileFactory, missilePos2, Quaternion.identity);
            bossM1.transform.rotation = Quaternion.Euler(90, 0, 0);
            bossM2.transform.rotation = Quaternion.Euler(90, 0, 0);
            isFire = false;
        }


    }

    IEnumerator BossStopAndAttack()
    {

        speed = 0;
        yield return new WaitForSeconds(2f); // ���÷� 1�� ���
        speed = 5;

    }


    //���� ���� ����
    void BossSuicideAttack()
    {
        //���� ����Ʈ �ֱ�

        // 0.1�� �� ����
        Destroy(gameObject,0.1f);
        suicideATK.gameObject.SetActive(true);
      
    }
    
}
