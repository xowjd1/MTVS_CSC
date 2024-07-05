using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    /*
     x�ʸ��� �����ʿ��� ��ȯ�Ǽ� �����̵��� �Ѵ�.
     Ư�� : ���ǵ�, ü��
     
     �Ѿ˰� �浹�� ��
     itemHp = itemHp - bullet.damage;
     ���� itemHp <= 0 �̶��
     transform.DetachChildren() �θ�-�ڽ� ���踦 ���� �ڽ� ������Ʈ���� ����
     itemBox�� �ı��ϰ� ���� �ڽĿ�����Ʈ�� �÷��̾ Ÿ�����Ͽ� �̵�
     �÷��̾�� �����ϸ� ����Ʈ�� �����ϰ� �ɷ�ġ�� �ο��Ѵ�.

     ī�޶� �ڱ��� �̵��ϸ� �ı�.

     ========================
     ü�� ����ui�� �ո鿡 ǥ��
     �Ѿ˿� �ı��Ǹ� ����Ʈ �����ǰ� �������� �÷��̾�� �̵��ϰ�
     �����۰� �÷��̾ �����ϸ� ����Ʈ�� �Բ� �÷��̾� ��ȭ

     */

    public float speed = 10f; // �ӵ�
    public int itemHP; // ü��
    public int maxItemHP; // ������ �ִ�ü��
    public int boxDamage =1; // �ڽ��� �浹�Ҷ� �÷��̾ ���� ������
    Vector3 dir = Vector3.back; // �̵�����
    bool isHit = false; // �Ѿ˿� �¾Ҵ��� ����
    bool isDroneHit = false; // ����Ѿ˿� �¾Ҵ��� ����
    bool isMissileHit = false; // �̻��Ͽ� �¾Ҵ��� ����


    // public GameObject Bullet;

    Bullet bullet;
    DroneBullet dBullet;
    Missile missile;
    Rigidbody rigid;

    void OnEnable()
    { 
       itemHP = maxItemHP; // ������ �� ü���� �ִ�ü������ ����

    }

    void Update()
    {
       transform.position += dir * speed * Time.deltaTime;

        //ī�޶� �ڱ��� �̵��ϸ� �ı�.
        if (transform.position.z <= -5.0f)
        {
            Destroy(gameObject);
            Debug.Log("������ �ڽ� ī�޶� �ڷ� �̵� �ı�.");
        }

       
        if (isHit)
         {
          itemHP -= bullet.bDamage;
            isHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��
            //itemHP �� 0 ���ϰ� �Ǹ�
            if (itemHP <= 0)
            {
                ItemHPMinus(); // �̺�Ʈ(�Լ�)�� �ҷ��´�.
            }
         }
        if (isDroneHit)
        {
            itemHP -= dBullet.damage;
            isDroneHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��
            //itemHP �� 0 ���ϰ� �Ǹ�
            if (itemHP <= 0)
            {
                ItemHPMinus(); // �̺�Ʈ(�Լ�)�� �ҷ��´�.
            }
        }
        if (isMissileHit)
        {
            itemHP -= missile.damage;
            isMissileHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��
            //itemHP �� 0 ���ϰ� �Ǹ�
            if (itemHP <= 0)
            {
                ItemHPMinus(); // �̺�Ʈ(�Լ�)�� �ҷ��´�.
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
                isHit = true;
                Debug.Log("Bullet Hit");
            }
        }
        if (other.CompareTag("DroneBullet"))
        {
            // �浹�� �Ѿ��� Bullet ������Ʈ�� ������
            dBullet = other.GetComponent<DroneBullet>();
            if (dBullet != null)
            {
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
                isMissileHit = true;
                Debug.Log("Missile Hit");
            }
        }

    }


    void ItemHPMinus()
    {
        //����Ʈ ����, �ı��Ѵ�.
        //�ڽ� ������Ʈ �и�.
        transform.DetachChildren();
        Destroy(gameObject);

    }
}
