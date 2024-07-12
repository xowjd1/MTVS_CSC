using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public TutoSystem tutoSystem;
    public float speed = 5f; // 플레이어 이동속도
    private Rigidbody rb;


    private void Start()
    {
        GameManager.instance.player = this;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");


        Vector3 go = new Vector3(h, 0, 0) * speed;
        rb.velocity = go;

       
    }

  
   
}
