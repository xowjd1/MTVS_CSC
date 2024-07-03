using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileFirePosition : MonoBehaviour
{
    // ���� ����� ���ʹ̸� �����Ѵ�
    // ���ʹ̸� �����ߴٸ� �߻��Ѵ�.
    // ���ʹ̸� �����Ҷ� �ѱ� ���ʸ� �����ϵ��� �Ѵ�.
    // ������ ���� ����� ���ʹ̸� �Ѿ˿��� �˷��ش�.

    public GameObject missileFactory;
    public float missileSpawnTime; // �Ѿ� �߻� �ֱ� �ð�
    public float detectionRadius; // ���� ������ �ݰ�
    public LayerMask targetLayer; // Ÿ������ ���� ���̾�
    private float currentTime;


    
    void Update()
    {
        currentTime += Time.deltaTime;

        // ���� �ֱ⸶��, ���ʹ̸� �����ߴٸ� �߻�
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
            // ���� ����� �� ã��
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

            // �߻��� ���� �ִ� ���
            if (nearestEnemy != null)
            {
                return true;
            }
        }

        return false;
    }

    void Fire()
    {

        // �Ѿ��� ���� ���� ����Ʈ���� ��ȯ
        GameObject bullet = Instantiate(missileFactory, transform.position, Quaternion.identity);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
