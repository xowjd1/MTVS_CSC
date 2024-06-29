using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMapTrigger : MonoBehaviour
{
    // �÷��̾�� ������ NewMapSpawner ������ ���� ��ȯ�Ѵ�.
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
            // �ڷ�ƾ�� �����Ͽ� 5�� �Ŀ� ������Ʈ�� ��Ȱ��ȭ�Ѵ�.
            StartCoroutine(DestroyAfterDelay(destroyTime));

            // �ڷ�ƾ�� �� ���� �����ϱ� ���� isTouchDes�� �ٽ� false�� ����
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
        // �ڷ�ƾ�� �����Ͽ� 5�� �Ŀ� ������Ʈ�� ��Ȱ��ȭ�Ѵ�.
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
