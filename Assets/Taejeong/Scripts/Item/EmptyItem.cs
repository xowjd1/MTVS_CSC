using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyItem : MonoBehaviour
{
    public float speed = 10f; // �ӵ�
    Vector3 dir = Vector3.back; // �̵�����




    void Start()
    {
        
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
