using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    public ItemBox itemBox;

    public float speed = 10f; // �ӵ�
    Vector3 dir = Vector3.back; // �̵�����

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;

        //ī�޶� �ڱ��� �̵��ϸ� �ı�.
        if (transform.position.z <= -5.0f)
        {
            Destroy(gameObject);
            //Debug.Log("������ �ڽ� ī�޶� �ڷ� �̵� �ı�.");
        }
       
        if(itemBox.itemHP <= 0)
        {
            transform.DetachChildren();
            Destroy(gameObject);
        }


    }

 
}
