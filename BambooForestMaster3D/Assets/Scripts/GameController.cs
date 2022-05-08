using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField]
    private GameObject gameOverPanel;

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        GameManager.Instance.GameOver();
    }

    public void ReStart()
    {
        GameManager.Instance.ReStart();
        SceneManager.LoadScene("GameScene");
    }

    public void Main()
    {
        GameManager.Instance.Main();
        SceneManager.LoadScene("MainScene");
    }

}
