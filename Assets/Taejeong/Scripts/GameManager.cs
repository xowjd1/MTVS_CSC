using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;

    [Header("�� �Ѿ� �⺻ ������")]
    public int damage = 10;
    public int sgDamage = 12;
    public int mgDamage = 3;
    [Header("�� �÷��̾� ����")]
    public int kill;
    
    public bool isShotGun = false;
    public bool isShotGun5 = false;
    public bool isShotGunEnd = false;

    [Header("�� ���� �ý��� �Ŵ���")]
    public float time;
   


    

    private void Awake()
    {
        instance = this;
    }



    void Start()
    {
        
    }

   
    void Update()
    {
        if(isShotGun5)
        {
            isShotGun = false;
        }
    }

    void GameStart()
    {

    }

    void GameOver()
    {

    }
}
