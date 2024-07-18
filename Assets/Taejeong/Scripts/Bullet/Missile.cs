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

    bool isEnemy = false; // 에너미와 충돌했는지 여부
    bool isBox = false; // 아이템 박스와 충돌했는지 여부
    bool isLine = false; // 파괴라인과 충돌했는지 여부
    bool isBoss = false;


    public Transform target;

    public void Init(Transform _startTr, Transform _endTr, float _speed, float _newPointDistanceFromStartTr, float _newPointDistanceFromEndTr)
    {
        target = _endTr;
        speed = _speed;

        // 끝에 도착할 시간을 랜덤으로 준다
        maxTime = Random.Range(0.8f, 1.0f);

        // 시작 지점.
        points[0] = _startTr.position;

        // 시작 지점을 기준으로 랜덤 포인트 지정
        points[1] = _startTr.position +
            (_newPointDistanceFromStartTr * Random.Range(-1.0f, 1.0f) * _startTr.right) + // X (좌, 우 전체)
            (_newPointDistanceFromStartTr * Random.Range(-0.15f, 1.0f) * _startTr.up) + // Y (아래쪽 조금, 위쪽 전체)
            (_newPointDistanceFromStartTr * Random.Range(-1.0f, -0.8f) * _startTr.forward); // Z (뒤 쪽만)

        // 도착 지점을 기준으로 랜덤 포인트 지정
        points[2] = _endTr.position +
            (_newPointDistanceFromEndTr * Random.Range(-1.0f, 1.0f) * _endTr.right) + // X (좌, 우 전체)
            (_newPointDistanceFromEndTr * Random.Range(-1.0f, 1.0f) * _endTr.up) + // Y (위, 아래 전체)
            (_newPointDistanceFromEndTr * Random.Range(0.8f, 1.0f) * _endTr.forward); // Z (앞 쪽만)

        // 도착 지점
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

        // 경과 시간 계산
        currentTime += Time.deltaTime * speed;

        // 베지어 곡선으로 X,Y,Z 좌표 얻기
        transform.position = new Vector3(
            CubicBezierCurve(points[0].x, points[1].x, points[2].x, points[3].x),
            CubicBezierCurve(points[0].y, points[1].y, points[2].y, points[3].y),
            CubicBezierCurve(points[0].z, points[1].z, points[2].z, points[3].z)
        );

        //충돌했다면 총알을 파괴한다. 파괴될때 이펙트 실행하기
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
        // (0~1)의 값에 따라 베지어 곡선 값을 구하기 때문에, 비율에 따른 시간을 구했다.
        float t = currentTime / maxTime; // (현재 경과 시간 / 최대 시간)

        // 방정식.
        return Mathf.Pow((1 - t), 3) * a
            + Mathf.Pow((1 - t), 2) * 3 * t * b
            + Mathf.Pow(t, 2) * 3 * (1 - t) * c
            + Mathf.Pow(t, 3) * d;

    }

    private void OnTriggerEnter(Collider other)
    {
        // 닿은 태그가 Enemy 라면 ( 에너미와의 상호작용)
        if (other.tag == "Enemy")
        {
            isEnemy = true; // 에너미와 충돌했으니 true 전환
                            // Debug.Log("불렛 - 에너미 충돌"); // 확인용 콘솔메세지 출력
        }
        if (other.tag == "Boss")
        {
            isBoss = true;
        }
        // 닿은 태그가 ItemBox 라면 ( 아이템 박스와의 상호작용)
        if (other.tag == "ItemBox")
        {
            isBox = true; // 아이템박스와 충돌했으니 true 전환
                          //  Debug.Log("불렛 - 아이템박스 충돌"); // 확인용 콘솔메세지 출력

        }
        // 닿은 태그가 BulletDestroyLine 라면 ( 일정거리 이상 넘어갔을 때 불렛 삭제 )
        if (other.tag == "BulletDestroyLine")
        {
            isLine = true; // 파괴라인과 충돌했으니 true 전환
                           //  Debug.Log("불렛 - 파괴라인 충돌"); // 확인용 콘솔메세지 출력

        }

    }
}
