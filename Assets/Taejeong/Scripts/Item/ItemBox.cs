using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    /*
     x�ʸ��� �����ʿ��� ��ȯ�Ǽ� �����̵��� �Ѵ�.
     Ư�� : ���ǵ�, ü��
     ü���� 0�� �Ǹ� �ı��ȴ�.

     ī�޶� �ڱ��� �̵��ϸ� �ı�.

     ========================
     ü�� ����ui�� �ո鿡 ǥ��
     �Ѿ˿� �ı��Ǹ� ����Ʈ �����ǰ� �������� �÷��̾�� �̵��ϰ�
     �����۰� �÷��̾ �����ϸ� ����Ʈ�� �Բ� �÷��̾� ��ȭ

     */

    public float speed = 10f; // �ӵ�
    public int itemHp; // ü��
    public int maxItemHp; // ������ �ִ�ü��
    Vector3 dir = Vector3.back; // �̵�����
    bool isHit = false; // �Ѿ˿� �¾Ҵ��� ����

    public GameObject Bullet;

    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();

        itemHp = maxItemHp; // ������ �� ü���� �ִ�ü������ ����
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

        /*
         if(isHit)
         {
          itemHP = itemHP - Bullet�� ������;
         }
          
          if(itemHP <= 0)
          ����Ʈ ����, �ı��Ѵ�.
          �ڽ� ������Ʈ�� �÷��̾�� ������.
         */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            isHit = true;
        }
    }

    }
