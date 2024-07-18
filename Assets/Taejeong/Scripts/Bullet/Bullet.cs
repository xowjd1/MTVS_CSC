using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameManager gameManager;
    public int bDamage; // �Ѿ� ������
    public FirePosition firePosition;
    public GameObject impactPrefab;

    bool isEnemy = false; // ���ʹ̿� �浹�ߴ��� ����
    bool isBox = false; // ������ �ڽ��� �浹�ߴ��� ����
    bool isLine = false; // �ı����ΰ� �浹�ߴ��� ����
    bool isBoss = false;


    public float speed; // �Ѿ� �ӵ�
    public Vector3 dir = Vector3.forward; // ������ ������


    void Update()
    {
        // �Ѿ� �������� GameManager�� �ν��Ͻ��� damage�� �ǽð� ������Ʈ
        bDamage = GameManager.instance.damage;

        if (GameManager.instance.isShotGun || GameManager.instance.isShotGun5
             || GameManager.instance.isShotGunEnd)
        {
            //firePosition.isShotGun = true;
            
            speed = 3.5f;
            transform.position += dir * speed * Time.deltaTime;
                
            // 90�� ������ ȸ��
            transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            bDamage = GameManager.instance.sgDamage;
            if(transform.position.z >= 15)
            {
                Destroy(gameObject);
            }    
        }

        //�浹�ߴٸ� �Ѿ��� �ı��Ѵ�.
        if (isEnemy)
            Destroy(gameObject);
            
        if (isBox)
            Destroy(gameObject);

        if (isLine)
            Destroy(gameObject);

        if (isBoss)
            Destroy(gameObject);


    }

    private void OnTriggerEnter(Collider other)
    {
        // ���� �±װ� Enemy ��� ( ���ʹ̿��� ��ȣ�ۿ�)
        if (other.tag == "Enemy")
        {
            isEnemy = true; // ���ʹ̿� �浹������ true ��ȯ               
            Instantiate(impactPrefab,transform.position,Quaternion.identity);
        }
        if (other.tag == "Boss")
        {
            isBoss = true;
            Instantiate(impactPrefab, transform.position, Quaternion.identity);
        }
        // ���� �±װ� ItemBox ��� ( ������ �ڽ����� ��ȣ�ۿ�)
        if (other.tag == "ItemBox")
        {
            isBox = true; // �����۹ڽ��� �浹������ true ��ȯ
            Instantiate(impactPrefab, transform.position, Quaternion.identity);

        }
        // ���� �±װ� BulletDestroyLine ��� ( �����Ÿ� �̻� �Ѿ�� �� �ҷ� ���� )
        if (other.tag == "BulletDestroyLine")
        {
            isLine = true; // �ı����ΰ� �浹������ true ��ȯ
         

        }

    }

}
