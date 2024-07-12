using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;

    

    [Header("★ 총알 기본 데미지")]
    public int damage = 10;
    public int sgDamage = 12;
    public int mgDamage = 3;
    [Header("★ 플레이어 스탯")]
    public int kill;
    
    public bool isShotGun = false;
    public bool isShotGun5 = false;
    public bool isShotGunEnd = false;


    [Header("★ 게임 시스템 매니저")]
    public bool isTutorial = false;
    public bool isGameStart = false; 
    public float time;
    public int randomMin;
    public int randomMax;





    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        
    }

   
    void Update()
    {
        if(isGameStart)
        time += Time.deltaTime;




        if(isShotGun5)
        {
            isShotGun = false;
        }
    }

    public void GameStart()
    {
        GameManager.instance.isTutorial = false;
        GameManager.instance.isGameStart = true;
        SceneManager.LoadScene("GameScene");
    }
    public void TutorialStart()
    {
        GameManager.instance.isTutorial = true; // GameManager의 필드나 변수를 초기화합니다.
        SceneManager.LoadScene("TutoScene");
    }
    public void StartScene()
    {
        GameManager.instance.isTutorial = false;
        SceneManager.LoadScene("StartScene");
    }


    public void GameExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


   
   


}
