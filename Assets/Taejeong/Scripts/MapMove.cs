using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    public float speed = 10f; // �� �̵��ӵ�
    Vector3 dir = Vector3.back; // �� �������

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
}
