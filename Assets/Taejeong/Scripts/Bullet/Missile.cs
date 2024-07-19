using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Analytics;
using static UnityEngine.GraphicsBuffer;

public class Missile : MonoBehaviour
{
    Vector3[] points = new Vector3[4];

    private float maxTime = 0;
    private float currentTime = 0;
    private float speed;

    public int damage;

    bool isEnemy = false; // ���ʹ̿� �浹�ߴ��� ����
    bool isBox = false; // ������ �ڽ��� �浹�ߴ��� ����
    bool isLine = false; // �ı����ΰ� �浹�ߴ��� ����
    bool isBoss = false;


    public Transform target;

    public void Init(Transform _startTr, Transform _endTr, float _speed, float _newPointDistanceFromStartTr, float _newPointDistanceFromEndTr)
    {
        target = _endTr;
        speed = _speed;

        // ���� ������ �ð��� �������� �ش�
        maxTime = Random.Range(0.8f, 1.0f);

        // ���� ����.
        points[0] = _startTr.position;

        // ���� ������ �������� ���� ����Ʈ ����
        points[1] = _startTr.position +
            (_newPointDistanceFromStartTr * Random.Range(-1.0f, 1.0f) * _startTr.right) + // X (��, �� ��ü)
            (_newPointDistanceFromStartTr * Random.Range(-0.15f, 1.0f) * _startTr.up) + // Y (�Ʒ��� ����, ���� ��ü)
            (_newPointDistanceFromStartTr * Random.Range(-1.0f, -0.8f) * _startTr.forward); // Z (�� �ʸ�)

        // ���� ������ �������� ���� ����Ʈ ����
        points[2] = _endTr.position +
            (_newPointDistanceFromEndTr * Random.Range(-1.0f, 1.0f) * _endTr.right) + // X (��, �� ��ü)
            (_newPointDistanceFromEndTr * Random.Range(-1.0f, 1.0f) * _endTr.up) + // Y (��, �Ʒ� ��ü)
            (_newPointDistanceFromEndTr * Random.Range(0.8f, 1.0f) * _endTr.forward); // Z (�� �ʸ�)

        // ���� ����
        points[3] = _endTr.position;

        transform.position = _startTr.position;
    }

    void Update()
    {
        if (target != null)
        {
            points[3] = target.position;

        }
        if (currentTime > maxTime)
        {
            return;
        }

        // ��� �ð� ���
        currentTime += Time.deltaTime * speed;

        // ������ ����� X,Y,Z ��ǥ ���
        transform.position = new Vector3(
            CubicBezierCurve(points[0].x, points[1].x, points[2].x, points[3].x),
            CubicBezierCurve(points[0].y, points[1].y, points[2].y, points[3].y),
            CubicBezierCurve(points[0].z, points[1].z, points[2].z, points[3].z)
        );

        //�浹�ߴٸ� �Ѿ��� �ı��Ѵ�. �ı��ɶ� ����Ʈ �����ϱ�
        if (isEnemy)
            Destroy(gameObject);
        if (isBox)
            Destroy(gameObject);
        if (isLine)
            Destroy(gameObject);
        if (isBoss)
            Destroy(gameObject);

        if (target == null)
        {
            
            Destroy(gameObject);
            return; 
        }
    }

    private float CubicBezierCurve(float a, float b, float c, float d)
    {
        // (0~1)�� ���� ���� ������ � ���� ���ϱ� ������, ������ ���� �ð��� ���ߴ�.
        float t = currentTime / maxTime; // (���� ��� �ð� / �ִ� �ð�)

        // ������.
        return Mathf.Pow((1 - t), 3) * a
            + Mathf.Pow((1 - t), 2) * 3 * t * b
            + Mathf.Pow(t, 2) * 3 * (1 - t) * c
            + Mathf.Pow(t, 3) * d;

    }

    private void OnTriggerEnter(Collider other)
    {
        // ���� �±װ� Enemy ��� ( ���ʹ̿��� ��ȣ�ۿ�)
        if (other.tag == "Enemy")
        {
            isEnemy = true; // ���ʹ̿� �浹������ true ��ȯ
                            // Debug.Log("�ҷ� - ���ʹ� �浹"); // Ȯ�ο� �ָܼ޼��� ���
        }
        if (other.tag == "Boss")
        {
            isBoss = true;
        }
        // ���� �±װ� ItemBox ��� ( ������ �ڽ����� ��ȣ�ۿ�)
        if (other.tag == "ItemBox")
        {
            isBox = true; // �����۹ڽ��� �浹������ true ��ȯ
                          //  Debug.Log("�ҷ� - �����۹ڽ� �浹"); // Ȯ�ο� �ָܼ޼��� ���

        }
        // ���� �±װ� BulletDestroyLine ��� ( �����Ÿ� �̻� �Ѿ�� �� �ҷ� ���� )
        if (other.tag == "BulletDestroyLine")
        {
            isLine = true; // �ı����ΰ� �浹������ true ��ȯ
                           //  Debug.Log("�ҷ� - �ı����� �浹"); // Ȯ�ο� �ָܼ޼��� ���

        }

    }
}
