using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

 /* 1. 스폰지역에서 스폰된다.
    5. 체력 > 숫자로 메쉬에 ui로 붙여서 표시
  */
public class Enemy : MonoBehaviour
{

    Rigidbody rigid;

    public float speed = 15f; // 에너미 스피드
    public int hp; // 에너미 체력
    Vector3 dir = Vector3.back; // 에너미 진행방향


    public Transform target; // 플레이어 타겟
    bool isTouchLine = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // 일정 거리까지 직선으로 이동.
    // 일정 거리 이후 플레이어를 쫓아온다.
    void Update()
    {
       //라인 충돌 전 직선 이동
       if(!isTouchLine)
        {
            transform.position += dir * speed * Time.deltaTime;
        }
       else
       //라인 충돌 후 플레이어에게 이동
        {
            dir = target.transform.position - transform.position;
            dir.Normalize();
            transform.position += dir * speed * Time.deltaTime;
        }
    }
    //트리거라인 충돌이벤트
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "TriggerLine")
        {
            isTouchLine = true;
        }
    }

}
