using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MissileFirePosition : MonoBehaviour
{
    // ���� ����� ���ʹ̸� �����Ѵ�
    // ���ʹ̸� �����ߴٸ� �߻��Ѵ�.
    // ���ʹ̸� �����Ҷ� �ѱ� ���ʸ� �����ϵ��� �Ѵ�.
    // ������ ���� ����� ���ʹ̸� �Ѿ˿��� �˷��ش�.

    public GameObject missileFactory; // �̻��� ������.
    public GameObject target; // ���� ����.
    float currentTime;
    public float fireTime =1;


    [Header("�̻��� ���")]
    public float speed = 2; // �̻��� �ӵ�.
    public float distanceFromStart = 1.0f; // ���� ������ �������� �󸶳� ������.
    public float distanceFromEnd = 5.0f; // ���� ������ �������� �󸶳� ������.
    public int shotCount = 3; // �� �� �� �߻��Ұ���.
    [Range(0, 1)] public float interval = 0.15f;
    public int shotCountEveryInterval = 1; // �ѹ��� �� ���� �߻��Ұ���.

    public float radius; // ���� �ݰ�


    private void Update()
    {
        currentTime += Time.deltaTime;

        // �߻�ð��� �ǰ� , ���ʹ̰� ����Ǹ� �߻�
        if (currentTime >= fireTime)
        {
            // ���� ����� �� ã��
            GameObject closestEnemy = FindClosestEnemy();

            if (closestEnemy != null)
            {
                target = closestEnemy;
                CreateMissile();
                currentTime = 0;
            }

        }
    }
    // �̻��� �߻�
    void CreateMissile()
    {
        int _shotCount = shotCount;
        while (_shotCount > 0)
        {
            for (int i = 0; i < shotCountEveryInterval; i++)
            {
                // Ÿ���� �÷��̾� �������� �̵��ϸ� �Ƚ��
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
    // ���� ����� ���ʹ� ã��
    GameObject FindClosestEnemy()

    {   // "Enemy" ���̾� ��������
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
