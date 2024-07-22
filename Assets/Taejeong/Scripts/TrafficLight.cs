using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public Color yellowLight;
    public float blinkInterval = 0.5f; // ±ôºýÀÌ´Â °£°Ý (ÃÊ ´ÜÀ§)
    private float timer;

    private void Start()
    {
        yellowLight = new Color(1,1,1,0);
    }


    void Update()
    {
        timer += Time.deltaTime;
        if(timer == 0)
        {
            yellowLight = new Color(1, 1, 1, 0);
        }


        if(timer >= blinkInterval)
        {
            yellowLight = new Color(1, 1, 1, 1);
            timer = 0;
        }
    }
}
