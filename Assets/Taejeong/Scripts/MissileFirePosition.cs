using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MissileFirePosition : MonoBehaviour
{
    // ���� ����� ���ʹ̸� �����Ѵ�
    // ���ʹ̸� �����ߴٸ� �߻��Ѵ�.
    // ���ʹ̸� �����Ҷ� �ѱ� ���ʸ� �����ϵ��� �Ѵ�.
    // ������ ���� ����� ���ʹ̸� �Ѿ˿��� �˷��ش�.

    public GameObject missileFactory;
    public float missileSpawnTime; // �Ѿ� �߻� �ֱ� �ð�
    public float radius = 0f;
    public Collider[] colliders;
    public Collider nearestEnemy;
    public LayerMask targetLayer; // Ÿ������ ���� ���̾�
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

        // ���� �ֱ⸶��, ���ʹ̸� �����ߴٸ� �߻�
        if (currentTime >= missileSpawnTime && nearestEnemy != null)
        {
                Fire();
            Debug.Log("MissileFire");

            currentTime = 0;
        }
    }
   
    void Fire()
    {

        // �Ѿ��� ���� ���� ����Ʈ���� ��ȯ
        GameObject missile = Instantiate(missileFactory, transform.position, Quaternion.identity);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
