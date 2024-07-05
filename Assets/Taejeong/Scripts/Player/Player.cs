using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameManager gameManager;
    public float speed = 5f; // 플레이어 이동속도
    private Rigidbody rb;

    public int pHasGrenades;
    public GameObject grenadeobj;

    bool gDown;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        pHasGrenades = GameManager.instance.hasGrenades;
        GetInput();
        Grenade();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");


        Vector3 go = new Vector3(h, 0, 0) * speed;
        rb.velocity = go;

       
    }

    void GetInput()
    {
        gDown = Input.GetButtonDown("Jump");
    }

    void Grenade()
    {
        if (pHasGrenades == 0)
            return;

        if(gDown)
        {

            Vector3 grenadeThrowPos = new Vector3(-0.7f,0.13f,0.21f);
            Vector3 spawnPosition = transform.position + grenadeThrowPos;
            GameObject instantGrenade = Instantiate(grenadeobj, spawnPosition, Quaternion.identity);

            Vector3 force = new Vector3(0, 0, 8);

            Rigidbody rigidGrenade = instantGrenade.GetComponent<Rigidbody>();
            rigidGrenade.AddForce(force,ForceMode.Impulse);
            rigidGrenade.AddTorque(Vector3.back * 10, ForceMode.Impulse);
            GameManager.instance.UpdateGrenadeCount(pHasGrenades - 1);
            pHasGrenades--;
            Debug.Log("Throw G");
        }
    }
}
