using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    public float speed = 10f; // 맵 이동속도
    Vector3 dir = Vector3.back; // 맵 진행방향

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
}
