using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontMoveLine : MonoBehaviour
{
    Player player;
    bool isPlayerIN = false;
    bool isPlayerOut = true;

    private void Update()
    {
        if(isPlayerIN)
        {
            player.speed = 0;
            isPlayerIN = false;
        }
        if(isPlayerOut)
        {
            player.speed = 10;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트가 플레이어인 경우
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerIN = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerIN = false;
            isPlayerOut = true;
        }
    }

}
