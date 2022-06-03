using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static bool gameOver = false;

    public GameObject gameOverUI;


    private void Start()
    {
        gameOver = false;
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (gameOver)
            return;

        if (Stats.Lives <= 0) {
            EndGame();
        }

    }

    void EndGame()
    {

        gameOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;

    }

    public void WinLevel()
    {
        PlayerPrefs.SetInt("levelReached", 2);
        Time.timeScale = 0f;

    }
}
