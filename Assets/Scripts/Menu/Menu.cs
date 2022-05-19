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

    public GameObject menuPanel;
    public GameObject shopPanel;

    int highscore;
    int coins;

    private void Start()
    {
        BackToMenu();

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

    public void ExitGame()
    {
        // to jest do przetestowania w buildzie gry
        Application.Quit();
    }

    public void GoToShop()
    {
        menuPanel.SetActive(false);
        shopPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        shopPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
}
