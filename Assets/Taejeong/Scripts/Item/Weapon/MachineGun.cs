using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    public GameManager gameManager;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Transform ngun = GameObject.Find("Player").transform.GetChild(0);
            Transform dgun = GameObject.Find("Player").transform.GetChild(1);
            Transform shotGun3 = GameObject.Find("Player").transform.GetChild(2);
            Transform mg = GameObject.Find("Player").transform.GetChild(3);

            if (mg != null)
            {
                ngun.gameObject.SetActive(false);
                dgun.gameObject.SetActive(false);
                shotGun3.gameObject.SetActive(false);
                mg.gameObject.SetActive(true);
                GameManager.instance.isShotGun = false;
                GameManager.instance.isShotGun5 = false;
                GameManager.instance.isShotGunEnd = true;
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
