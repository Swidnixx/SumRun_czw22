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

    // Dependecies
    public Text scoreText;
    public GameObject endGamePanel;
    public Text coinText;

    // Game Settings
    public float worldScrollingSpeed = 0.1f;
    private float score;
    private bool gamePending = true;
    private int coins = 0;
    private int highScore;

    // Powerups
    public PowerupManager powerupManager;
    public Immortality immortality;
    public Magnet magnet;

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    private void Start()
    {
        immortality = powerupManager.currentLevelBattery;
        magnet = powerupManager.currentLevelMagnet;

        immortality.isActive = false;
        magnet.isActive = false;

        coins = PlayerPrefs.GetInt("Coins", 0);
        coinText.text = coins.ToString();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void FixedUpdate()
    {
        score += worldScrollingSpeed;
        scoreText.text = score.ToString("0");

        if(score > highScore)
        {
            highScore = (int)score;
        }
    }

    public void GameOver()
    {
        endGamePanel.SetActive(true);
        gamePending = false;
        Time.timeScale = 0;

        PlayerPrefs.SetInt("HighScore", highScore);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void CoinCollected(int count = 1)
    {
        coins += count;
        coinText.text = coins.ToString();
        PlayerPrefs.SetInt("Coins", coins);
    }

    public void ImmortalityCollected()
    {
        if(immortality.isActive)
        {
            CancelInvoke(nameof(CancelImmortality));
            CancelImmortality();
        }

        immortality.isActive = true;
        worldScrollingSpeed += immortality.speedBoost;
        Invoke(nameof(CancelImmortality), immortality.duration);
    }

    void CancelImmortality()
    {
        worldScrollingSpeed -= immortality.speedBoost;
        immortality.isActive = false;
    }

    public void MagnetCollected()
    {
        if(magnet.isActive)
        {
            CancelInvoke(nameof(CancelMagnet));
        }

        magnet.isActive = true;
        Invoke(nameof(CancelMagnet), magnet.duration);
    }

    void CancelMagnet()
    {
        magnet.isActive = false;
    }
}
