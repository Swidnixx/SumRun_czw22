using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text highScoreText;
    public Text coinsText;
    public Text soundText;

    int highscore;
    int coins;

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("HighScore", 0);
        coins = PlayerPrefs.GetInt("Coins", 0);
        UpdateUI();
    }

    private void UpdateUI()
    {
        highScoreText.text = highscore.ToString();
        coinsText.text = coins.ToString();

        // SoundManager do zrobienia
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void SoundToggle()
    {

    }
}
