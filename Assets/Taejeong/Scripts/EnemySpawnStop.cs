using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnStop : MonoBehaviour
{
    GameManager gameManager;
    public float bossSpawnTime;

    void Update()
    {
        if(GameManager.instance.time >= bossSpawnTime)
        {
            Destroy(gameObject);
        }
    }
}
