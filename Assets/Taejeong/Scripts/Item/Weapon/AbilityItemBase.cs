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

    public GameManager gameManager;
    public float speed = 20f; // 0.01���� �� �� ������ ����
    public float rotSpeed = 100f; // ȸ���ӵ�
    public Rigidbody target; // Ÿ��
    Vector3 dir;


    void OnEnable()
    {
        // Ÿ���� GameManager�� �ν��Ͻ� player�� rigidbody�� �ٲ��ش�.
        target = GameManager.instance.player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ������ ������ ȸ��
        transform.Rotate(Vector3.right * rotSpeed * Time.deltaTime); 

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
