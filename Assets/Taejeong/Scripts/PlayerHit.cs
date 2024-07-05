using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{

    public Player player;
    public GameManager gameManager;
    ItemBox itemBox;
    Bullet bullet;
    DamageUp damageUp;
    LifeUp lifeUp;
    FirePosition firePosition;
    FireSpeedUp fireSpeedUp;

    public int playerLife;
    public int playerMaxLife = 1;
    public float bsTime = 0.5f; 
    public float mgbsTime = 0.25f; 
    public float fSpeedUp = 0.1f;
    public float mgfSpeedUp = 0.05f;
   

    bool isPlayerHit = false;
    bool isLifeUp = false;
    bool isFSpeedUp = false;
    bool isDamageUp = false;

   
    void OnEnable()
    {
        playerLife = playerMaxLife; // 스폰될 때 체력은 최대체력으로 설정
  
    }


    void Update()
    {
        if (isPlayerHit) // 아이템 박스와 부딪혀서 체력이 1 깎임
        {
            playerLife -= itemBox.boxDamage;
            isPlayerHit = false; // 데미지를 한번만 받아야하니까 false처리
            
        }
        if (isLifeUp) // life 추가 아이템 획득시 체력이 1 오름
        {
            playerLife += lifeUp.lifeUpCount;
            isLifeUp = false;

        }
        if (playerLife <= 0) // 체력이 0 이하가 되면 죽음
        {
            // 플레이어 죽음
            Destroy(gameObject);
        }
        if (isFSpeedUp) // 공격속도 증가 아이템 획득시 공속 0.2 증가
        {
            bsTime -= fSpeedUp;
            mgbsTime -= mgfSpeedUp;
            isFSpeedUp = false;
        }
        if(isDamageUp)
        {
            GameManager.instance.damage += damageUp.damageUpCount;
            GameManager.instance.sgDamage += damageUp.damageUpCount;
            GameManager.instance.mgDamage += damageUp.mgDamageUpCount;
            isDamageUp = false;
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
        if (other.CompareTag("LifeUp"))
        {
            lifeUp = other.GetComponent<LifeUp>();
            if (lifeUp != null && !isLifeUp) // isLifeUp가 false일 때만 실행
            {
                isLifeUp = true;
                Debug.Log("hit LifeUp!");

                // AbilityItem 처리 후 Collider 비활성화
                other.gameObject.SetActive(false);
            }
        }
        if (other.CompareTag("FireSpeedUp"))
        {
            fireSpeedUp = other.GetComponent<FireSpeedUp>();
            if (fireSpeedUp != null && !isFSpeedUp) // isLifeUp가 false일 때만 실행
            {
                isFSpeedUp = true;
                Debug.Log("hit FireSpeedUp!");

                // AbilityItem 처리 후 Collider 비활성화
                other.gameObject.SetActive(false);
            }
        }
        if (other.CompareTag("DamageUp"))
        {
            damageUp = other.GetComponent<DamageUp>();
            if (damageUp != null && !isDamageUp) // isLifeUp가 false일 때만 실행
            {
                isDamageUp = true;
                Debug.Log("hit DamageUp!");

                // AbilityItem 처리 후 Collider 비활성화
                other.gameObject.SetActive(false);
            }
        }



    }
}
