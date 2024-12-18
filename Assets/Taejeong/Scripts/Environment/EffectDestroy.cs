using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroy : MonoBehaviour
{
    float currentTime;
    float DTime = 0.5f;

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= DTime)
            Destroy(gameObject);
    }
}
