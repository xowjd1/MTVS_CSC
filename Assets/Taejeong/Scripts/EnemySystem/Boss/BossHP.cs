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
        //Text�� hp ����
        bossHP.text = GameManager.instance.bossHP.ToString();

        //HP�� 0���ϰ� �ȴٸ� UI�� ���ֱ�
        if (GameManager.instance.bossHP <= 0)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}
