using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMapTrigger : MonoBehaviour
{
    // 플레이어와 닿으면 NewMapSpawner 지점에 맵을 소환한다.
    bool isTouchDes = false;
    bool isTouchNew = false;
    bool isSpawnMap = false;
    public GameObject NewMapSpawn;
    public GameObject Map;
    public float destroyTime = 5f;


    void Update()
    {
        if (isTouchDes)
        {
            // 코루틴을 시작하여 5초 후에 오브젝트를 비활성화한다.
            StartCoroutine(DestroyAfterDelay(destroyTime));

            // 코루틴을 한 번만 실행하기 위해 isTouchDes를 다시 false로 설정
            isTouchDes = false;
        }

        if (isTouchNew)
        {
            isSpawnMap = true;
            SpawnNewMap();

            isTouchNew = false;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MapDestroy")
        {
            isTouchDes = true;
        }

        if (other.tag == "Player")
        {
            isTouchNew = true;
        }

    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        // 코루틴을 시작하여 5초 후에 오브젝트를 비활성화한다.
        yield return new WaitForSeconds(delay);
        transform.parent.gameObject.SetActive(false);
    }

    void SpawnNewMap()
    { 
        if (isSpawnMap)
        {
            Instantiate(Map, NewMapSpawn.transform.position, Quaternion.identity);
            isSpawnMap = false;
        }
    }
}
