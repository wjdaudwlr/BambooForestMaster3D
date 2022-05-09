using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public TextMesh text_Timer;
    private float time_start;
    private float time_current;
    private bool isEnded;

    public Text scoreText;
    public Text bestScoreText;

    private void Start()
    {
        Reset_Timer();
    }
    void Update()
    {
        if (isEnded)
            return;
        
        Check_Timer();
    }

    private void Check_Timer()
    {
        time_current = Time.time - time_start;

        text_Timer.text = $"{time_current:N2}";
        Debug.Log(time_current);

        if(GameManager.Instance.gState == GameState.GameOver)
        {
            End_Timer();
            GameOver();
        }
    }

    private void End_Timer()
    {
        Debug.Log("End");
        text_Timer.text = $"{time_current:N2}";
        isEnded = true;
    }

    private void Reset_Timer()
    {
        time_start = Time.time;
        time_current = 0;
        text_Timer.text = $"{time_current:N2}";
        isEnded = false;
        Debug.Log("Start");
    }

    private void GameOver()
    {
        scoreText.text = $"{time_current:N2}";
        if(PlayerPrefs.GetFloat("BestScore") < time_current)
        {
            PlayerPrefs.SetFloat("BestScore", time_current);
        }

        bestScoreText.text = $"{PlayerPrefs.GetFloat("BestScore"):N2}";
    }
}
