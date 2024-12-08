using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunFive : MonoBehaviour
{
    public GameManager gameManager;
    FirePosition firePosition;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Transform ngun = GameObject.Find("Player").transform.GetChild(0);
            Transform dgun = GameObject.Find("Player").transform.GetChild(4);
            Transform shotGun3 = GameObject.Find("Player").transform.GetChild(2);

            if (shotGun3 != null)
            {
                ngun.gameObject.SetActive(false);
                dgun.gameObject.SetActive(false);
                shotGun3.gameObject.SetActive(true);

                //FirePosition�� isShotGunFive �� true�� �ٲ��ش�.
               GameManager.instance.isShotGun5 = true;
            }
            else
            {
                Debug.Log("DoubleGun�� ã�� �� �����ϴ�.");
            }

            // �����Ƽ ������ �������
            gameObject.SetActive(false);
        }
    }
}
