using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplainManager : MonoBehaviour
{


    public Text expText;  // UI �ؽ�Ʈ ������Ʈ
    public GameObject expTextBox;  // ���� ���� UI
    public GameObject returnUI; // ����ȭ������ ���ư��� ui
    public TutoSystem tutoSystem;

    private string[] expLines;  // ���� ���� �迭
    private int currentLineIndex = 0;  // ���� ���� �ε���

    void Start()
    {
        // ���� ������ �ʱ�ȭ 
        expLines = new string[]
        {
           "�ȳ��Ͻʴϱ�. �޾ƿ� ���� �� ȯ���մϴ�.", //currentLineIndex = 0
           "�������� �̵��� [A],[��]�� �����ϰ� \n ���������� �̵��� [D],[��]�� �����մϴ�.",
           "���⸦ ������ �帮�ڽ��ϴ�.\n ������ �ڵ� �����Դϴ�.",
           "���� ��Ÿ�����ϴ�.\n �Ϲ� ���� �ѹ��̸� óġ�� �� �ֽ��ϴ�.",
           "������ ���, ���� ���ϸ� ü���� 1��ŭ �Ҹ�˴ϴ�. \n ü���� 0 ���ϰ� �Ǹ� ������ ����˴ϴ�.",
           "�������Դϴ�.\n ü���� 0 ���� ����� �ش� �������� ȹ���� �� �ֽ��ϴ�.",
           "������ �ڽ��� �ε��� ��� ü���� 1��ŭ �Ҹ�˴ϴ�.",
           "�÷��̾��� ������ �÷��ִ� �����۵� �Դϴ�.",
           "���ʺ��� ������ ����, \n���� �ӵ� ����, ü�� ���� ȿ���� �ֽ��ϴ�.",
           "������ ������� �Դϴ�.\n�׷� ������ ���ϴ�." //currentLineIndex = 9
        };

        // ���� �� ���� ���� ��Ȱ��ȭ
        expTextBox.SetActive(false);
        returnUI.SetActive(false);

        // ���� �� ���� ����
        StartCoroutine(StartDialogue());

    }

    IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(1f);  // ���� ���ð�

        // ��ȭ ���� Ȱ��ȭ
        expTextBox.SetActive(true);

        // ��ȭ ����
        while (currentLineIndex < expLines.Length)
        {
            expText.text = expLines[currentLineIndex];

            bool spacePressed = false;

            // ���� ���� �ε����� �ش��ϴ� ��� ���� ��������
            while (!spacePressed)
            {
                if ((currentLineIndex == 4 && tutoSystem.isEnemyDead && Input.GetButtonDown("Jump")) ||
                    (currentLineIndex == 6 && tutoSystem.isGetItem && Input.GetButtonDown("Jump")) ||
                    (currentLineIndex == 8 && tutoSystem.isGetStat && Input.GetButtonDown("Jump") ))
                    
                {
                    spacePressed = true;
                }
                else if ((currentLineIndex != 4 && currentLineIndex != 6 && currentLineIndex != 8) && Input.GetButtonDown("Jump"))
                {
                    spacePressed = true;
                }
                yield return null;  // ���� �����ӱ��� ��ٸ���.
            }


            currentLineIndex++;  // ������ ������ ���� ���� �ε��� �̵�


            //���� ���� system�� bool���� �������ش�.

            if (currentLineIndex == 2)
            {
                tutoSystem.isMove = true;
            }
            if (currentLineIndex == 3)
            {
                tutoSystem.isAttack = true;
            }
            if (currentLineIndex == 5 && tutoSystem.isEnemyDead)
            {
                tutoSystem.enemySpawn = true;
            }
            if (currentLineIndex == 7 && tutoSystem.isGetItem)
            {
                tutoSystem.itemSpawn = true;
            }
            if (currentLineIndex == 9)
            {
                tutoSystem.statItemSpawn = true;
                returnUI.SetActive(true);
            }






                // ��� ������ ������ �� ���� ���� ��Ȱ��ȭ
                if (currentLineIndex >= expLines.Length)
            {
                expTextBox.SetActive(false);
            }
        }
    }

}
