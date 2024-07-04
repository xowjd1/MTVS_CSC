using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MissileFirePosition : MonoBehaviour
{
    // 가장 가까운 에너미를 감지한다
    // 에너미를 감지했다면 발사한다.
    // 에너미를 감지할때 총구 앞쪽만 감지하도록 한다.
    // 감지한 가장 가까운 에너미를 총알에게 알려준다.

    public GameObject missileFactory;
    public float missileSpawnTime; // 총알 발사 주기 시간
    public float radius = 0f;
    public Collider[] colliders;
    public Collider nearestEnemy;
    public LayerMask targetLayer; // 타겟으로 삼을 레이어
    private float currentTime;

    
    void Update()
    {
        currentTime += Time.deltaTime;


        colliders = Physics.OverlapSphere(transform.position, radius, targetLayer);

        if (colliders.Length > 0)
        {
            float short_distance = Vector3.Distance(transform.position, colliders[0].transform.position);
            foreach (Collider col in colliders)
            {
                float short_distance2 = Vector3.Distance(transform.position, col.transform.position);
                if (short_distance > short_distance2)
                {
                    short_distance = short_distance2;
                    nearestEnemy = col;
                }
            }

        }

        // 일정 주기마다, 에너미를 감지했다면 발사
        if (currentTime >= missileSpawnTime && nearestEnemy != null)
        {
                Fire();
            Debug.Log("MissileFire");

            currentTime = 0;
        }
    }
   
    void Fire()
    {

        // 총알을 현재 스폰 포인트에서 소환
        GameObject missile = Instantiate(missileFactory, transform.position, Quaternion.identity);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
