using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    private static bool isPaused = false;
    private static bool isGameOver = false;
    private static TextMeshProUGUI gameOverScreen;
    private static HiScoreController hiScore;

    private void Start()
    {
        hiScore = GameObject.FindGameObjectWithTag("HiScore")
            .GetComponent<HiScoreController>();

        var gameOverObject = GameObject.FindGameObjectWithTag("GameOverScreen");
        gameOverScreen = gameOverObject
            .GetComponent<TextMeshProUGUI>();

        gameOverObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.anyKeyDown && isGameOver)
        {
            Restart();
        }
    }

    public static void GameOver()
    {
        isGameOver = true;
        TogglePause(true);
        ShowGameOverScreen();
    }

    private static void ShowGameOverScreen()
    {
        gameOverScreen.text = $"Game Over! Total Score is: {hiScore.totalScore}. Press any key to continue";
        gameOverScreen.gameObject.SetActive(true);
    }

    private void Restart()
    {
        TogglePause(false);
        isGameOver = false;

        var activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name, LoadSceneMode.Single);
    }

    private static void TogglePause(bool paused)
    {
        isPaused = paused;
        Time.timeScale = isPaused
            ? 0
            : 1;
    }
}
