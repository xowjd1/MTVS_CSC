using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplainManager : MonoBehaviour
{


    public Text expText;  // UI 텍스트 컴포넌트
    public GameObject expTextBox;  // 설명 상자 UI
    public GameObject returnUI; // 시작화면으로 돌아가는 ui
    public TutoSystem tutoSystem;

    private string[] expLines;  // 설명 문장 배열
    private int currentLineIndex = 0;  // 현재 설명 인덱스

    void Start()
    {
        // 설명 데이터 초기화 
        expLines = new string[]
        {
           "안녕하십니까. 메아에 오신 걸 환영합니다.", //currentLineIndex = 0
           "왼쪽으로 이동은 [A],[←]로 가능하고 \n 오른쪽으로 이동은 [D],[→]로 가능합니다.",
           "무기를 지급해 드리겠습니다.\n 공격은 자동 공격입니다.",
           "적이 나타났습니다.\n 일반 적은 한방이면 처치할 수 있습니다.",
           "근접할 경우, 공격 당하며 체력이 1만큼 소모됩니다. \n 체력이 0 이하가 되면 게임이 종료됩니다.",
           "아이템입니다.\n 체력을 0 으로 만들면 해당 아이템을 획득할 수 있습니다.",
           "아이템 박스와 부딪힐 경우 체력이 1만큼 소모됩니다.",
           "플레이어의 스탯을 올려주는 아이템들 입니다.",
           "왼쪽부터 데미지 증가, \n연사 속도 증가, 체력 증가 효과가 있습니다.",
           "설명은 여기까지 입니다.\n그럼 무운을 빕니다." //currentLineIndex = 9
        };

        // 시작 시 설명 상자 비활성화
        expTextBox.SetActive(false);
        returnUI.SetActive(false);

        // 시작 시 설명 시작
        StartCoroutine(StartDialogue());

    }

    IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(1f);  // 시작 대기시간

        // 대화 상자 활성화
        expTextBox.SetActive(true);

        // 대화 시작
        while (currentLineIndex < expLines.Length)
        {
            expText.text = expLines[currentLineIndex];

            bool spacePressed = false;

            // 현재 설명 인덱스에 해당하는 토글 상태 가져오기
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
                yield return null;  // 다음 프레임까지 기다린다.
            }


            currentLineIndex++;  // 설명이 끝나면 다음 설명 인덱스 이동


            //설명에 맞춰 system의 bool값을 변경해준다.

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






                // 모든 설명이 끝났을 때 설명 상자 비활성화
                if (currentLineIndex >= expLines.Length)
            {
                expTextBox.SetActive(false);
            }
        }
    }

}
