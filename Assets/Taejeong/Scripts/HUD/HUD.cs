using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public PlayerHit player;
    public GameObject gameDefeat;  // 게임 패배
    public GameObject gameWin;  // 게임 승리



    //GameScene
    // 게임 승리, 패배 텍스트 및 창

    // 게임승리 조건 > 보스 잡으면

    // 게임패배 조건 > 플레이어 죽음

    // Life Damage FireSpeed



    private void Awake()
    {

        gameDefeat.SetActive(false);
        gameWin.SetActive(false);
    }

    void Update()
    {
        GameDefeat();
        GameWin();
       
    }


    void GameDefeat()
    {
        if(player.isPlayerDefeat)
        gameDefeat.SetActive(true);
        


    }

    void GameWin()
    {
        if(GameManager.instance.isGameWin)
        gameWin.SetActive(true);

    }
 
}
