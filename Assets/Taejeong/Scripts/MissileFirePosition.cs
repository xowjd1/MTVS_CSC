using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileFirePosition : MonoBehaviour
{
    // 가장 가까운 에너미를 감지한다
    // 에너미를 감지했다면 발사한다.
    // 에너미를 감지할때 총구 앞쪽만 감지하도록 한다.
    // 감지한 가장 가까운 에너미를 총알에게 알려준다.

    public GameObject missileFactory;
    public float missileSpawnTime; // 총알 발사 주기 시간
    public float detectionRadius; // 적을 감지할 반경
    public LayerMask targetLayer; // 타겟으로 삼을 레이어
    private float currentTime;


    
    void Update()
    {
        currentTime += Time.deltaTime;

        // 일정 주기마다, 에너미를 감지했다면 발사
        if (currentTime >= missileSpawnTime  && ShouldFire())
        {
                Fire();

            currentTime = 0;
        }
    }
    bool ShouldFire()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, targetLayer);

        if (colliders.Length > 0)
        {
            // 가장 가까운 적 찾기
            Collider nearestEnemy = colliders[0];
            float shortestDistance = Vector3.Distance(transform.position, nearestEnemy.transform.position);

            foreach (Collider col in colliders)
            {
                float distance = Vector3.Distance(transform.position, col.transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    nearestEnemy = col;
                }
            }

            // 발사할 적이 있는 경우
            if (nearestEnemy != null)
            {
                return true;
            }
        }

        return false;
    }

    void Fire()
    {

        // 총알을 현재 스폰 포인트에서 소환
        GameObject bullet = Instantiate(missileFactory, transform.position, Quaternion.identity);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
