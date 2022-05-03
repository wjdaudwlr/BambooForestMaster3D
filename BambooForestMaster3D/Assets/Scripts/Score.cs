using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public TextMesh text_Timer;
    private float time_start;
    private float time_current;
    private float time_Max = 100f;
    private bool isEnded;

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
        }
    }

    private void End_Timer()
    {
        Debug.Log("End");
        time_current = time_Max;
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
}
