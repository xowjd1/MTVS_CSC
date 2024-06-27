using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    /*
     * 1~x���� ������ ���� > �迭
     * ������ ���� ���� spawnTime��
     * �������� ������ �� ���ʹ� ���� �ȵ�
     * 
     */
    public GameObject[] itemFactories;
    public float spawnTime = 1f; // ������ ���� ���� (��)

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
        // index�� �ش��ϴ� ������ ���丮�� �����ϴ� �޼���
        if (index >= 0 && index < itemFactories.Length)
        {
            GameObject go = Instantiate(itemFactories[index]);  // �������� ���� ���� ����Ʈ���� ��ȯ
            go.transform.position = transform.position; // �������� ����� ȸ���ؼ� ��Ÿ������
        }
        else
        {
            Debug.LogError("�߸��� �ε����� ������ ���丮�� �����Ϸ��� �õ��Ͽ����ϴ�.");
        }
    }
}
