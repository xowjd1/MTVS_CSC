using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{

    public Player player;
    public Enemy enemy;
    GameManager gameManager;
    Boss boss;
    ItemBox itemBox;
    Bullet bullet;
    DamageUp damageUp;
    LifeUp lifeUp;
    FirePosition firePosition;
    FireSpeedUp fireSpeedUp;

    [Header("★ 플레이어 체력")]
    public int playerLife;
    int playerMaxLife = 1;
    [Header("★ 연사 속도")]
    public float bsTime = 0.5f; 
    public float mgbsTime = 0.15f;
    public float sgTime = 0.7f;
    [Header("★ 연사 속도 아이템 수치")]
    public float fSpeedUp = 0.1f;
    public float mgfSpeedUp = 0.03f;
    public float sgSpeedUp = 0.07f;

    bool isPlayerHit = false;
    bool isPlayerEnemyHit = false;
    bool isLifeUp = false;
    bool isFSpeedUp = false;
    bool isDamageUp = false;
    bool isPlayerBossHit = false;

   
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
        if (isPlayerEnemyHit) // 아이템 박스와 부딪혀서 체력이 1 깎임
        {
            playerLife -= enemy.damage;
            isPlayerEnemyHit = false; // 데미지를 한번만 받아야하니까 false처리

        }
        if (isPlayerBossHit) // 아이템 박스와 부딪혀서 체력이 1 깎임
        {
            playerLife -= boss.damage;
            isPlayerBossHit = false; // 데미지를 한번만 받아야하니까 false처리

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
        if (isFSpeedUp) // 공격속도 증가 아이템
        {
            bsTime -= fSpeedUp;
            mgbsTime -= mgfSpeedUp;
            sgTime -= sgSpeedUp;
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
        if ((other.CompareTag("ItemBox")))
        {
            itemBox = other.GetComponent<ItemBox>(); //이게 중요함
            if (itemBox != null)
            {
                isPlayerHit = true;

            }
        }
            if ((other.CompareTag("Enemy")))
            {
                enemy = other.GetComponent<Enemy>(); //이게 중요함
                if (enemy != null)
                {
                    isPlayerEnemyHit = true;

                }
            }
            if ((other.CompareTag("Boss")))
            {
                boss = other.GetComponent<Boss>(); //이게 중요함
                if (boss != null)
                {
                    isPlayerBossHit = true;

                }
            }
            if (other.CompareTag("LifeUp"))
            {
                lifeUp = other.GetComponent<LifeUp>();
                if (lifeUp != null && !isLifeUp) // isLifeUp가 false일 때만 실행
                {
                    isLifeUp = true;


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

                    // AbilityItem 처리 후 Collider 비활성화
                    other.gameObject.SetActive(false);
                }
            }


        
    }
}
