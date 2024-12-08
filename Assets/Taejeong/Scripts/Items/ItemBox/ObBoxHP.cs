using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObBoxHP : MonoBehaviour
{
    Text itemBoxHP;
    OB ob;

    void Awake()
    {
        itemBoxHP = GetComponent<Text>();
        ob = GetComponentInParent<OB>();
    }


    void Update()
    {
        //Text랑 hp 연동
        itemBoxHP.text = ob.obHP.ToString();

        //HP가 0이하가 된다면 UI도 없애기
        if (ob.obHP <= 0)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}
