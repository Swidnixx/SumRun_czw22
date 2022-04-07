using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Multiple GameManagers in the Scene");
        }
    }

    //Dependecies
    public Text scoreText;
    public GameObject endGamePanel;

    // Game Settings
    public float worldScrollingSpeed = 0.1f;
    private float score;
    private bool gamePending = true;

    private void FixedUpdate()
    {
        score += worldScrollingSpeed;
        scoreText.text = score.ToString("0");
    }

    public void GameOver()
    {
        endGamePanel.SetActive(true);
        gamePending = false;
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
