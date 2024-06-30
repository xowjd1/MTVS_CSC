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

    //public GameManager gameManager;
    public float speed = 20f; // 0.01���� �� �� ������ ����
    public float rotSpeed = 100f; // ȸ���ӵ�
    public Transform target;
    Vector3 dir;


    void Awake()
    {
        
    }
    void Start()
    {
        
    }
    void OnEnable()
    {

    }

    void Update()
    {
        transform.Rotate(Vector3.right * rotSpeed * Time.deltaTime); // ������ ȸ��

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
