using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Missile : MonoBehaviour
{
    // �� �̻��Ͽ� ���� ���� ����� Ÿ�� ã��
    public float speed;
    public float radius = 0f;
    public LayerMask layer;
    public Collider[] colliders;
    public Collider short_enemy;

    bool isEnemy = false; // ���ʹ̿� �浹�ߴ��� ����
    bool isBox = false; // ������ �ڽ��� �浹�ߴ��� ����
    bool isLine = false; // �ı����ΰ� �浹�ߴ��� ����

    void Start()
    {

    }

    void Update()
    {
        colliders = Physics.OverlapSphere(transform.position, radius, layer);

        if (colliders.Length == 0)
            return;

        if (colliders.Length > 0)
        {
            float short_distance = Vector3.Distance(transform.position, colliders[0].transform.position);
            foreach (Collider col in colliders)
            {
                float short_distance2 = Vector3.Distance(transform.position, col.transform.position);
                if (short_distance > short_distance2)
                {
                    short_distance = short_distance2;
                    short_enemy = col;
                }
            }

        }
        if (colliders.Length >0 && short_enemy != null)
        {
            transform.position += (short_enemy.transform.position - transform.position).normalized * speed * Time.deltaTime;
        }
        //�浹�ߴٸ� �Ѿ��� �ı��Ѵ�.
        if (isEnemy)
            Destroy(gameObject);
        if (isBox)
            Destroy(gameObject);
        if (isLine)
            Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
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
