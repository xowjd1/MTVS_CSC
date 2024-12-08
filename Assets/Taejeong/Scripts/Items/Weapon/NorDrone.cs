using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NorDrone : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 이펙트 생성

            // target의 자식오브젝트로 걸려있는 DoubleGun SetActive(true)

            Transform ndrone = GameObject.Find("Player").transform.GetChild(1);

            if (ndrone != null)
            {
                ndrone.gameObject.SetActive(true);
            }
           

            // 어빌리티 아이템 사라지게
            gameObject.SetActive(false);
        }
    }
}
