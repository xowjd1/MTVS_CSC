using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleGun : MonoBehaviour
{
    public GameManager gameManager;
    Player player;
    public GameObject target;

    void Start()
    {
        //target = gameManager.in
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ����Ʈ ����

            // target�� �ڽĿ�����Ʈ�� �ɷ��ִ� DoubleGun SetActive(true)
            Transform dgun = GameObject.Find("Player").transform.GetChild(3);
            if (dgun != null)
            {
                
                dgun.gameObject.SetActive(true);
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
