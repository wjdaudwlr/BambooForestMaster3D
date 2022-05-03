using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState  // 게임상태
{
    Main,              // 메인상태
    Run,               // 게임실행 
    Pause,             // 일시정지
    GameOver           // 게임오버
}

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;  
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public static GameManager Instance
    {
        get
        {
            if(null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public GameState gState;

    private void Start()
    {
        gState = GameState.Main;
    }

    public void GameStart()
    {
        SceneManager.LoadScene("GameScene");
        gState = GameState.Run;
    }

    public void GameOver()
    {
        gState = GameState.GameOver;
    }

}
