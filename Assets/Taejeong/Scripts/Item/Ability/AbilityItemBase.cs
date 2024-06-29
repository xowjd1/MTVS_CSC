using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityItemBase : MonoBehaviour
{
    // �θ�� ��������
    // �÷��̾�� �̵��Ѵ�
    // �÷��̾�� �����ϸ�
    // ������鼭
    // ����Ʈ�� �����ϰ�
    // �÷��̾��� �ɷ�ġ�� ���⸦ ��ü�Ѵ�.

    public float speed;
    public GameObject target;
    Vector3 dir;


    void Awake()
    {
       
    }
    void Start()
    {

    }


    void Update()
    {
        // �θ�� ��������
        if (transform.parent == null)
        {
            //Debug.Log("�θ� ������Ʈ�κ��� ����");

            dir = target.transform.position - transform.position;
            dir.Normalize();
            transform.position += dir * speed * Time.deltaTime;

        }
    }


}
