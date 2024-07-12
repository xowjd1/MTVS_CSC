using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    Text myText;
    public PlayerHit player;
    public Boss boss;
    public GameObject gameDefeat;  // ���� �й�
    public GameObject gameWin;  // ���� �¸�



    //GameScene
    // ���� �¸�, �й� �ؽ�Ʈ �� â

    // ���ӽ¸� ���� > ���� ������

    // �����й� ���� > �÷��̾� ����

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
