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
    [Header("�� �÷��̾� ����")]
    //public int playerLife = 1;
    public int kill;

    [Header("�� ���� �ý��� �Ŵ���")]
    public float time;
   


    //bool isPlayerHit = false; 
    

    private void Awake()
    {
        instance = this;
    }





    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    void GameStart()
    {

    }

    void GameOver()
    {

    }
}
