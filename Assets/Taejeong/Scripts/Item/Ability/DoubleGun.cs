using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleGun : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject target;

    void Start()
    {
        target = gameManager.player;

    }



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 이펙트 생성

            // target의 자식오브젝트로 걸려있는 DoubleGun SetActive(true)
            Transform dgun = GameObject.Find("Player").transform.GetChild(2);
            if (dgun != null)
            {
                
                dgun.gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("DoubleGun을 찾을 수 없습니다.");
            }

            // 어빌리티 아이템 사라지게
            gameObject.SetActive(false);
        }
    }

}
