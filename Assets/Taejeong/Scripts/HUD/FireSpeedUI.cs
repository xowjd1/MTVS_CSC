using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireSpeedUI : MonoBehaviour
{

    Text FSCount;
    public PlayerHit player;

    private void Awake()
    {
        FSCount = GetComponent<Text>();
    }


    void Update()
    {
        FSCount.text = "Lv." + player.speedupCount.ToString();
    }
}


