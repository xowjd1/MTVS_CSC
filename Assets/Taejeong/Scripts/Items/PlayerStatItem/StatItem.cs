using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatItem : MonoBehaviour
{
    public float speed = 10f;


    private void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
    }

}
