using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDrone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ����Ʈ ����

            // target�� �ڽĿ�����Ʈ�� �ɷ��ִ� DoubleGun SetActive(true)

            Transform tdrone = GameObject.Find("Player").transform.GetChild(6);

            if (tdrone != null)
            {
                tdrone.gameObject.SetActive(true);
            }
          

            // �����Ƽ ������ �������
            gameObject.SetActive(false);
        }
    }
}
