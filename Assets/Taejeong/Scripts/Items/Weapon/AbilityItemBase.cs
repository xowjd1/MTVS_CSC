using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityItemBase : MonoBehaviour
{
    // 부모와 떨어지면
    // 플레이어에게 이동한다
    // 플레이어와 접촉하면
    // 사라지면서
    // 이펙트를 생성하고
    // 플레이어의 능력치나 무기를 교체한다.

    public GameManager gameManager;
    public float speed = 20f; // 0.01보다 좀 더 빠르게 조정
    public float rotSpeed = 100f; // 회전속도
    public Rigidbody target; // 타겟
    public Rigidbody gameOverDummy; // 게임오버용 더미
    Vector3 dir;
    public bool isTuto = false;

    void Update()
    {
     
        if(target == null || GameManager.instance.player == null)
        {
            target = gameOverDummy;
            
        }
        
        else
        {
            target = GameManager.instance.player.GetComponent<Rigidbody>();
        }
        // 아이템 오른쪽 회전
        transform.Rotate(Vector3.right * rotSpeed * Time.deltaTime); 

        // 부모와 떨어지면
        if (transform.parent == null)
        {
            //Debug.Log("부모 오브젝트로부터 독립");

            dir = target.transform.position - transform.position;
            dir.Normalize();
            transform.position += dir * speed * Time.deltaTime;

        }
    }

}
