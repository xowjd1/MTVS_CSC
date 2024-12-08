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
    public int boxDamage = 1; // �ڽ��� �浹�Ҷ� �÷��̾ ���� ������

    bool isHit = false; // �Ѿ˿� �¾Ҵ��� ����
    bool isDroneHit = false; // ����Ѿ˿� �¾Ҵ��� ����
    bool isMissileHit = false; // �̻��Ͽ� �¾Ҵ��� ����
    bool isMGBulletHit = false; // �ӽŰǿ� �¾Ҵ��� ����


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

            isHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��
            //itemHP �� 0 ���ϰ� �Ǹ�
            if (obHP <= 0)
            {
                OBHPMinus(); // �̺�Ʈ(�Լ�)�� �ҷ��´�.
            }
        }
        if (isMGBulletHit)
        {
            obHP -= mgBullet.mgDamage;
            isMGBulletHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��
            //itemHP �� 0 ���ϰ� �Ǹ�
            if (obHP <= 0)
            {
                OBHPMinus(); // �̺�Ʈ(�Լ�)�� �ҷ��´�.
            }
        }
        if (isDroneHit)
        {
            obHP -= dBullet.damage;
            isDroneHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��
            //itemHP �� 0 ���ϰ� �Ǹ�
            if (obHP <= 0)
            {
                OBHPMinus(); // �̺�Ʈ(�Լ�)�� �ҷ��´�.
            }
        }
        if (isMissileHit)
        {
            obHP -= missile.damage;
            isMissileHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��
            //itemHP �� 0 ���ϰ� �Ǹ�
            if (obHP <= 0)
            {
                OBHPMinus(); // �̺�Ʈ(�Լ�)�� �ҷ��´�.
            }
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
                StartCoroutine(ScaleBox());
                isHit = true;
                Debug.Log("Bullet Hit");
            }
        }
        if (other.CompareTag("MGBullet"))
        {
            // �浹�� �Ѿ��� Bullet ������Ʈ�� ������
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
            // �浹�� �Ѿ��� Bullet ������Ʈ�� ������
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
            // �浹�� �Ѿ��� Bullet ������Ʈ�� ������
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
        //����Ʈ ����, �ı��Ѵ�.
        //�ڽ� ������Ʈ �и�.
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
