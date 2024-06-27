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
    public int hp; // ü��
    Vector3 dir = Vector3.back; // �̵�����

    Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
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
    }

}
