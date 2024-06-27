using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

 /* 1. ������������ �����ȴ�.
    5. ü�� > ���ڷ� �޽��� ui�� �ٿ��� ǥ��
  */
public class Enemy : MonoBehaviour
{

    Rigidbody rigid;

    public float speed = 15f; // ���ʹ� ���ǵ�
    public int hp; // ���ʹ� ü��
    Vector3 dir = Vector3.back; // ���ʹ� �������


    public Transform target; // �÷��̾� Ÿ��
    bool isTouchLine = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // ���� �Ÿ����� �������� �̵�.
    // ���� �Ÿ� ���� �÷��̾ �Ѿƿ´�.
    void Update()
    {
       //���� �浹 �� ���� �̵�
       if(!isTouchLine)
        {
            transform.position += dir * speed * Time.deltaTime;
        }
       else
       //���� �浹 �� �÷��̾�� �̵�
        {
            dir = target.transform.position - transform.position;
            dir.Normalize();
            transform.position += dir * speed * Time.deltaTime;
        }
    }
    //Ʈ���Ŷ��� �浹�̺�Ʈ
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "TriggerLine")
        {
            isTouchLine = true;
        }
    }

}
