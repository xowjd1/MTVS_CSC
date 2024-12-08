using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPro : MonoBehaviour
{
    public float rotSpeed = 300f; // 회전속도

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
    }
}
