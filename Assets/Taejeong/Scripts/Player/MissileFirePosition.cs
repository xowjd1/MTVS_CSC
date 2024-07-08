using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MissileFirePosition : MonoBehaviour
{
    // 가장 가까운 에너미를 감지한다
    // 에너미를 감지했다면 발사한다.
    // 에너미를 감지할때 총구 앞쪽만 감지하도록 한다.
    // 감지한 가장 가까운 에너미를 총알에게 알려준다.

    public GameObject missileFactory; // 미사일 프리팹.
    public GameObject target; // 도착 지점.
    float currentTime;
    public float fireTime =1;


    [Header("미사일 기능")]
    public float speed = 2; // 미사일 속도.
    public float distanceFromStart = 1.0f; // 시작 지점을 기준으로 얼마나 꺾일지.
    public float distanceFromEnd = 5.0f; // 도착 지점을 기준으로 얼마나 꺾일지.
    public int shotCount = 3; // 총 몇 개 발사할건지.
    [Range(0, 1)] public float interval = 0.15f;
    public int shotCountEveryInterval = 1; // 한번에 몇 개씩 발사할건지.

    public float radius; // 감지 반경


    private void Update()
    {
        currentTime += Time.deltaTime;

        // 발사시간이 되고 , 에너미가 검출되면 발사
        if (currentTime >= fireTime)
        {
            // 가장 가까운 적 찾기
            GameObject closestEnemy = FindClosestEnemy();

            if (closestEnemy != null)
            {
                target = closestEnemy;
                CreateMissile();
                currentTime = 0;
            }

        }
    }
    // 미사일 발사
    void CreateMissile()
    {
        int _shotCount = shotCount;
        while (_shotCount > 0)
        {
            for (int i = 0; i < shotCountEveryInterval; i++)
            {
                // 타겟이 플레이어 뒤쪽으로 이동하면 안쏘게
                if (target.transform.position.z > 3f)
                {
                    GameObject missile = Instantiate(missileFactory);
                    missile.GetComponent<Missile>().Init(this.gameObject.transform, target.transform, speed, distanceFromStart, distanceFromEnd);
                }
                _shotCount--;
            }
            
        new WaitForSeconds(interval);
        }
    }
    // 가장 가까운 에너미 찾기
    GameObject FindClosestEnemy()

    {   // "Enemy" 레이어 가져오기
        LayerMask enemyLayerMask = LayerMask.GetMask("Enemy");
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, enemyLayerMask);

        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (Collider collider in colliders)
        {
            GameObject enemyGameObject = collider.gameObject;

            float distance = Vector3.Distance(enemyGameObject.transform.position, currentPosition);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemyGameObject;
            }
        }

        return closestEnemy;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
