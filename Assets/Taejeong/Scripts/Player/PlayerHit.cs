using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{

    public Player player;
    public Enemy enemy;
    public GameManager gameManager;
    Boss boss;
    ItemBox itemBox;
    Bullet bullet;
    DamageUp damageUp;
    LifeUp lifeUp;
    FirePosition firePosition;
    FireSpeedUp fireSpeedUp;

    public int playerLife;
    public int playerMaxLife = 1;
    public float bsTime = 0.5f; 
    public float mgbsTime = 0.1f; 
    public float fSpeedUp = 0.1f;
    public float mgfSpeedUp = 0.02f;
   

    bool isPlayerHit = false;
    bool isPlayerEnemyHit = false;
    bool isLifeUp = false;
    bool isFSpeedUp = false;
    bool isDamageUp = false;
    bool isPlayerBossHit = false;

   
    void OnEnable()
    {
        playerLife = playerMaxLife; // ������ �� ü���� �ִ�ü������ ����
  
    }


    void Update()
    {
        if (isPlayerHit) // ������ �ڽ��� �ε����� ü���� 1 ����
        {
            playerLife -= itemBox.boxDamage;
            isPlayerHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��
            
        }
        if (isPlayerEnemyHit) // ������ �ڽ��� �ε����� ü���� 1 ����
        {
            playerLife -= enemy.damage;
            isPlayerEnemyHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��

        }
        if (isPlayerBossHit) // ������ �ڽ��� �ε����� ü���� 1 ����
        {
            playerLife -= boss.damage;
            isPlayerBossHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��

        }
        if (isLifeUp) // life �߰� ������ ȹ��� ü���� 1 ����
        {
            playerLife += lifeUp.lifeUpCount;
            isLifeUp = false;

        }
        if (playerLife <= 0) // ü���� 0 ���ϰ� �Ǹ� ����
        {
            // �÷��̾� ����
            Destroy(gameObject);
        }
        if (isFSpeedUp) // ���ݼӵ� ���� ������ ȹ��� ���� 0.2 ����
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
        if ((other.CompareTag("ItemBox")))
        {
            itemBox = other.GetComponent<ItemBox>(); //�̰� �߿���
            if (itemBox != null)
            {
                isPlayerHit = true;

            }
        }
            if ((other.CompareTag("Enemy")))
            {
                enemy = other.GetComponent<Enemy>(); //�̰� �߿���
                if (enemy != null)
                {
                    isPlayerEnemyHit = true;

                }
            }
            if ((other.CompareTag("Boss")))
            {
                boss = other.GetComponent<Boss>(); //�̰� �߿���
                if (boss != null)
                {
                    isPlayerBossHit = true;

                }
            }
            if (other.CompareTag("LifeUp"))
            {
                lifeUp = other.GetComponent<LifeUp>();
                if (lifeUp != null && !isLifeUp) // isLifeUp�� false�� ���� ����
                {
                    isLifeUp = true;


                    // AbilityItem ó�� �� Collider ��Ȱ��ȭ
                    other.gameObject.SetActive(false);
                }
            }
            if (other.CompareTag("FireSpeedUp"))
            {
                fireSpeedUp = other.GetComponent<FireSpeedUp>();
                if (fireSpeedUp != null && !isFSpeedUp) // isLifeUp�� false�� ���� ����
                {
                    isFSpeedUp = true;


                    // AbilityItem ó�� �� Collider ��Ȱ��ȭ
                    other.gameObject.SetActive(false);
                }
            }
            if (other.CompareTag("DamageUp"))
            {
                damageUp = other.GetComponent<DamageUp>();
                if (damageUp != null && !isDamageUp) // isLifeUp�� false�� ���� ����
                {
                    isDamageUp = true;

                    // AbilityItem ó�� �� Collider ��Ȱ��ȭ
                    other.gameObject.SetActive(false);
                }
            }


        
    }
}
