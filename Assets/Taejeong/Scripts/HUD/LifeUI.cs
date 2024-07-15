using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    public Image[] lifeImage;
    public PlayerHit player;


    void Awake()
    {

    }
    void Update()
    {
        Debug.Log("Player Life: " + player.playerLife);
        if (player.playerLife == 1)
        {
            lifeImage[0].color = new Color(1, 1, 1, 1);
            lifeImage[1].color = new Color(1, 1, 1, 0);
            lifeImage[2].color = new Color(1, 1, 1, 0);
            lifeImage[3].color = new Color(1, 1, 1, 0);
        }
        else if (player.playerLife == 2)
        {
            lifeImage[0].color = new Color(1, 1, 1, 1);
            lifeImage[1].color = new Color(1, 1, 1, 1);
            lifeImage[2].color = new Color(1, 1, 1, 0);
            lifeImage[3].color = new Color(1, 1, 1, 0);
        }
        else if(player.playerLife == 3)
        {
            lifeImage[0].color = new Color(1, 1, 1, 1);
            lifeImage[1].color = new Color(1, 1, 1, 1);
            lifeImage[2].color = new Color(1, 1, 1, 1);
            lifeImage[3].color = new Color(1, 1, 1, 0);
        }
        else if (player.playerLife == 4)
        {
            lifeImage[0].color = new Color(1, 1, 1, 1);
            lifeImage[1].color = new Color(1, 1, 1, 1);
            lifeImage[2].color = new Color(1, 1, 1, 1);
            lifeImage[3].color = new Color(1, 1, 1, 1);
        }
        else if(player == null)
        {
            lifeImage[0].color = new Color(1, 1, 1, 0);
            lifeImage[1].color = new Color(1, 1, 1, 0);
            lifeImage[2].color = new Color(1, 1, 1, 0);
            lifeImage[3].color = new Color(1, 1, 1, 0);
        }
    }


}
