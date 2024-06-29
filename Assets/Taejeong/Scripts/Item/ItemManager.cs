using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    /*
     * 1~x번의 아이템 제작 > 배열
     * 아이템 생성 간격 spawnTime초
     * 아이템이 생성될 때 에너미 생성 안됨
     * 
     */
    public GameObject[] itemFactories;
    public float spawnTime = 1f; // 아이템 생성 간격 (초)

    float currentTime;

    private void Start()
    {
        StartCoroutine(SpawnItemsCoroutine());
    }

    void Update()
    {
        currentTime += Time.deltaTime;
    }

    IEnumerator SpawnItemsCoroutine()
    {
        for (int i = 0; i < itemFactories.Length; i++)
        {
            SpawnItem(i);
            yield return new WaitForSeconds(spawnTime);
        }
    }

    void SpawnItem(int index)
    {
        // index에 해당하는 아이템 팩토리를 생성하는 메서드
        if (index >= 0 && index < itemFactories.Length)
        {
            GameObject go = Instantiate(itemFactories[index]);  // 아이템을 현재 스폰 포인트에서 소환
            go.transform.position = transform.position; // 프리팹이 제대로 회전해서 나타나도록
        }
        else
        {
            Debug.LogError("잘못된 인덱스로 아이템 팩토리를 생성하려고 시도하였습니다.");
        }
    }
}
