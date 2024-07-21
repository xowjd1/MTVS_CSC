using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public PlayerHit player;
    public GameObject gameDefeat;  // ���� �й�
    public GameObject gameWin;  // ���� �¸�



    //GameScene
    // ���� �¸�, �й� �ؽ�Ʈ �� â

    // ���ӽ¸� ���� > ���� ������

    // �����й� ���� > �÷��̾� ����

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
