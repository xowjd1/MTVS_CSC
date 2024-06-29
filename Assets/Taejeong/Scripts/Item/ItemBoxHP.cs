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
        itemBoxHP.text = itemBox.itemHP.ToString();

        //HP가 0이하가 된다면 UI도 없애기
        if(itemBox.itemHP <= 0)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}
