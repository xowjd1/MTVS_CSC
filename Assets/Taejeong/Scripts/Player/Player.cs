using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   // GameManager gameManager;
    public float speed = 5f; // �÷��̾� �̵��ӵ�
    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");


        Vector3 go = new Vector3(h, 0, 0) * speed;
        rb.velocity = go;

       
    }

  
   
}
