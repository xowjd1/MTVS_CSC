using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPro : MonoBehaviour
{
    public float rotSpeed = 300f; // ȸ���ӵ�

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
    }
}
