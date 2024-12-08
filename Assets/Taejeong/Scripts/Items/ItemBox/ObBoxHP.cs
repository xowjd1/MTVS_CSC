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
        //Text�� hp ����
        itemBoxHP.text = ob.obHP.ToString();

        //HP�� 0���ϰ� �ȴٸ� UI�� ���ֱ�
        if (ob.obHP <= 0)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}
