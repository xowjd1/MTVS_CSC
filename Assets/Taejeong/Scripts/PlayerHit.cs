using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public GameObject player;
    //public GameManager gameManager;
    ItemBox itemBox;

    public int playerLife;
    public int playerMaxLife = 1;

    bool isPlayerHit = false;

    void Awake()
    {
        
    }
    void OnEnable()
    {
        playerLife = playerMaxLife; // ������ �� ü���� �ִ�ü������ ����
    }


    void Update()
    {
        if (isPlayerHit)
        {
            playerLife -= itemBox.boxDamage;
            isPlayerHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��
            
        }
        if (playerLife <= 0)
        {
            // �÷��̾� ����
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if((other.CompareTag("ItemBox")))
        {
            itemBox = other.GetComponent<ItemBox>(); //�̰� �߿���
            if(itemBox != null)
            {
                isPlayerHit = true;
                Debug.Log("hit ItemBox");
            }
        }
    }
}
