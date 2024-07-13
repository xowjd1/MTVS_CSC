using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public GameManager gameManager;
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
                GameManager.instance.isShotGun = true;
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
