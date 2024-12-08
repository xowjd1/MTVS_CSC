using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ED2 : MonoBehaviour
{
    float currentTime;
    float DTime = 1.5f;

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= DTime)
            Destroy(gameObject);
    }
}
