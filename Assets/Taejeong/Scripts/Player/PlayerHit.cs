using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{

    public Player player;
    public Enemy enemy;
    Boss boss;
    ItemBox itemBox;
    OB obBox;
    BossMissile bossM;
    DamageUp damageUp;
    LifeUp lifeUp;
    FireSpeedUp fireSpeedUp;
    BossBomb bossBomb;
    AbilityItemBase aib;

    [Header("�� �÷��̾� ü��")]
    public int playerLife;
    int playerMaxLife = 1;

    [Header("�� ���� �ӵ�")]
    public float bsTime = 0.5f; 
    public float mgbsTime = 0.15f;
    public float sgTime = 1.0f;
    [Header("�� ���� �ӵ� ������ ��ġ")]
    public float fSpeedUp = 0.1f;
    public float mgfSpeedUp = 0.03f;
    public float sgSpeedUp = 0.07f;

    [Header("�� HUD �����")]
    public int damageupCount;
    public int speedupCount;
    public bool isPlayerDefeat = false;

    public GameObject itemGetEffect;

    bool isPlayerHit = false;
    bool isPlayerEnemyHit = false;
    public bool isLifeUp = false;
    public bool isFSpeedUp = false;
    public bool isDamageUp = false;
    bool isPlayerBossHit = false;

   
    void OnEnable()
    {
        playerLife = playerMaxLife; // ������ �� ü���� �ִ�ü������ ����
  
    }
    private void Start()
    {
        player = GameManager.instance.player;
    }

    void Update()
    {
       

        if (isPlayerHit) // ������ �ڽ��� �ε����� ü���� 1 ����
        {
            playerLife --;
            
            isPlayerHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��
            
        }
        if (isPlayerEnemyHit) // ������ �ڽ��� �ε����� ü���� 1 ����
        {
            playerLife -= enemy.damage;
            isPlayerEnemyHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��

        }
        if (isPlayerBossHit) // ������ �ڽ��� �ε����� ü���� 1 ����
        {
            playerLife --;
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
            isPlayerDefeat = true;
            Destroy(gameObject);
        }
        if (isFSpeedUp) // ���ݼӵ� ���� ������
        {
            bsTime -= fSpeedUp;
            mgbsTime -= mgfSpeedUp;
            sgTime -= sgSpeedUp;
            speedupCount++;
            isFSpeedUp = false;
        }
        if(isDamageUp)
        {
            damageupCount++;
            GameManager.instance.damage += damageUp.damageUpCount;
            GameManager.instance.sgDamage += damageUp.damageUpCount;
            GameManager.instance.mgDamage += damageUp.mgDamageUpCount;
            isDamageUp = false;
        }


        //������ ��� ����Ʈ ������ ü�� 100�� ����
        //if (Input.GetButtonDown("Fire3"))
        //{
        //    playerLife += 100;
        //}

    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("ItemBox")))
        {
            itemBox = other.GetComponent<ItemBox>(); //�̰� �߿���
            obBox = other.GetComponent<OB>();
            if (itemBox != null || obBox != null)
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
                bossM = other.GetComponent<BossMissile>();
                if (boss != null || bossM != null)
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
            if (other.CompareTag("BossBomb"))
            {
                bossBomb = other.GetComponent<BossBomb>();
                if (bossBomb != null)
                {
                    playerLife -= 5;
                }
            }
            if (other.CompareTag("WeaponItem"))
            {
            aib = other.GetComponent<AbilityItemBase>();
                if (aib != null)
                {
                Vector3 position = transform.position;
                position.y = 0.55f; 

                Instantiate(itemGetEffect, position, Quaternion.identity);
            }
            }



    }
}
