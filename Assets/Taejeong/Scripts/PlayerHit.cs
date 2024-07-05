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
        playerLife = playerMaxLife; // ������ �� ü���� �ִ�ü������ ����
  
    }


    void Update()
    {
        if (isPlayerHit) // ������ �ڽ��� �ε����� ü���� 1 ����
        {
            playerLife -= itemBox.boxDamage;
            isPlayerHit = false; // �������� �ѹ��� �޾ƾ��ϴϱ� falseó��
            
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
        if((other.CompareTag("ItemBox")))
        {
            itemBox = other.GetComponent<ItemBox>(); //�̰� �߿���
            if(itemBox != null)
            {
                isPlayerHit = true;
                Debug.Log("hit ItemBox");
            }
        }
        if (other.CompareTag("LifeUp"))
        {
            lifeUp = other.GetComponent<LifeUp>();
            if (lifeUp != null && !isLifeUp) // isLifeUp�� false�� ���� ����
            {
                isLifeUp = true;
                Debug.Log("hit LifeUp!");

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
                Debug.Log("hit FireSpeedUp!");

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
                Debug.Log("hit DamageUp!");

                // AbilityItem ó�� �� Collider ��Ȱ��ȭ
                other.gameObject.SetActive(false);
            }
        }



    }
}
