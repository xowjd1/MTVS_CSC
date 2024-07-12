using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    Text myText;
    public PlayerHit player;
    public Boss boss;
    public GameObject gameDefeat;  // 게임 패배
    public GameObject gameWin;  // 게임 승리



    //GameScene
    // 게임 승리, 패배 텍스트 및 창

    // 게임승리 조건 > 보스 잡으면

    // 게임패배 조건 > 플레이어 죽음

    // Life Damage FireSpeed



    private void Awake()
    {
        myText = GetComponent<Text>();
    }

    private void Start()
    {
        gameDefeat.SetActive(false);
        gameWin.SetActive(false);
    }




    void GameDefeat()
    {
        if(player.isPlayerDefeat)
        gameDefeat.SetActive(true);
        Debug.Log("Defeat");

    }

    void GameWin()
    {
        if(boss.isBossLose)
        gameWin.SetActive(true);
        Debug.Log("Win");
    }
}
