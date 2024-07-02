using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunFive : MonoBehaviour
{
    FirePosition firePosition;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Transform ngun = GameObject.Find("Player").transform.GetChild(0);
            Transform dgun = GameObject.Find("Player").transform.GetChild(1);
            Transform shotGun3 = GameObject.Find("Player").transform.GetChild(2);

            if (shotGun3 != null)
            {
                ngun.gameObject.SetActive(false);
                dgun.gameObject.SetActive(false);
                shotGun3.gameObject.SetActive(true);

                //FirePosition의 isShotGunFive 를 true로 바꿔준다.
                firePosition.isShotGunFive = true;
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
