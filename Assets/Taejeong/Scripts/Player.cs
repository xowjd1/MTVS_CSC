using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed; // �÷��̾� �̵��ӵ�


    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
       

        Vector3 dir = new Vector3(h, 0, 0);

        transform.position += dir * speed * Time.deltaTime;
    }
}
