using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NorDrone : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ����Ʈ ����

            // target�� �ڽĿ�����Ʈ�� �ɷ��ִ� DoubleGun SetActive(true)

            Transform ndrone = GameObject.Find("Player").transform.GetChild(4);

            if (ndrone != null)
            {
                ndrone.gameObject.SetActive(true);
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
