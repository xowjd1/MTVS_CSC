using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{
    Text bossHP;
    Boss boss;

    void Awake()
    {
        bossHP = GetComponent<Text>();
        boss = GetComponentInParent<Boss>();
    }


    void Update()
    {
        //Text랑 hp 연동
        bossHP.text = GameManager.instance.bossHP.ToString();

        //HP가 0이하가 된다면 UI도 없애기
        if (GameManager.instance.bossHP <= 0)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}
