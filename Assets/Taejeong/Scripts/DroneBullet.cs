using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBullet : MonoBehaviour
{
    public int damage;
    public float speed;
    bool isEnemy = false; // ���ʹ̿� �浹�ߴ��� ����
    bool isBox = false; // ������ �ڽ��� �浹�ߴ��� ����
    bool isLine = false; // �ı����ΰ� �浹�ߴ��� ����

    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;

        //�浹�ߴٸ� �Ѿ��� �ı��Ѵ�.
        if (isEnemy)
            Destroy(gameObject);
        if (isBox)
            Destroy(gameObject);
        if (isLine)
            Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        // ���� �±װ� Enemy ��� ( ���ʹ̿��� ��ȣ�ۿ�)
        if (other.tag == "Enemy")
        {
            isEnemy = true; // ���ʹ̿� �浹������ true ��ȯ
                            // Debug.Log("�ҷ� - ���ʹ� �浹"); // Ȯ�ο� �ָܼ޼��� ���
        }
        // ���� �±װ� ItemBox ��� ( ������ �ڽ����� ��ȣ�ۿ�)
        if (other.tag == "ItemBox")
        {
            isBox = true; // �����۹ڽ��� �浹������ true ��ȯ
                          //  Debug.Log("�ҷ� - �����۹ڽ� �浹"); // Ȯ�ο� �ָܼ޼��� ���

        }
        // ���� �±װ� BulletDestroyLine ��� ( �����Ÿ� �̻� �Ѿ�� �� �ҷ� ���� )
        if (other.tag == "BulletDestroyLine")
        {
            isLine = true; // �ı����ΰ� �浹������ true ��ȯ
                           //  Debug.Log("�ҷ� - �ı����� �浹"); // Ȯ�ο� �ָܼ޼��� ���

        }

    }


}
