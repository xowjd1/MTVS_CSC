using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBoxHP : MonoBehaviour
{

    Text itemBoxHP;
    ItemBox itemBox;

    void Awake()
    {
        itemBoxHP = GetComponent<Text>();
        itemBox = GetComponentInParent<ItemBox>();
    }

    
    void Update()
    {
        itemBoxHP.text = itemBox.itemHp.ToString();
    }
}
