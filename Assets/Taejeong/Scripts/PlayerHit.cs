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
        playerLife = playerMaxLife; // 스폰될 때 체력은 최대체력으로 설정
    }


    void Update()
    {
        if (isPlayerHit)
        {
            playerLife -= itemBox.boxDamage;
            isPlayerHit = false; // 데미지를 한번만 받아야하니까 false처리
            
        }
        if (playerLife <= 0)
        {
            // 플레이어 죽음
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if((other.CompareTag("ItemBox")))
        {
            itemBox = other.GetComponent<ItemBox>(); //이게 중요함
            if(itemBox != null)
            {
                isPlayerHit = true;
                Debug.Log("hit ItemBox");
            }
        }
    }
}
