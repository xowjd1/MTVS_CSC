using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageUI : MonoBehaviour
{
    Text damageCount;
    public PlayerHit player;

    private void Awake()
    {
        damageCount = GetComponent<Text>();
    }


    void Update()
    {
        damageCount.text = player.damageupCount.ToString();
    }
}
