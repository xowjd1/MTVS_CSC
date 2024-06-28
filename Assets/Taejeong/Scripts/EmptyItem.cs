using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyItem : MonoBehaviour
{
    public float speed = 10f; // 속도
    Vector3 dir = Vector3.back; // 이동방향




    void Start()
    {
        
    }


    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;

        //카메라 뒤까지 이동하면 파괴.
        if (transform.position.z <= -5.0f)
        {
            Destroy(gameObject);
            Debug.Log("아이템 박스 카메라 뒤로 이동 파괴.");
        }
    }
}
