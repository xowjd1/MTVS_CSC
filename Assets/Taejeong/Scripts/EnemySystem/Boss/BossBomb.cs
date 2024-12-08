using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossBomb : MonoBehaviour
{
    bool isBomb = false;
    void Update()
    {
        if(transform.parent == null && !isBomb)
        {
            AudioSource bbSound = GetComponent<AudioSource>();
            bbSound.Play();
            isBomb = true;
        }
    }
        
    
    
}
