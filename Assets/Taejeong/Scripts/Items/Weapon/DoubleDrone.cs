using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDrone : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ����Ʈ ����
           
            // target�� �ڽĿ�����Ʈ�� �ɷ��ִ� DoubleGun SetActive(true)

            Transform ddrone = GameObject.Find("Player").transform.GetChild(5);

            if (ddrone != null)
            {
                ddrone.gameObject.SetActive(true);
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
