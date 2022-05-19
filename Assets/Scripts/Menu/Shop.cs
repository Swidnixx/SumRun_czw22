using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public PowerupManager powerupManager;

    public Text coinsText;
    int coins;

    public Text batteryInfoText;
    public Text magnetInfoText;

    public Button batteryUpgradeButton;

    private void Start()
    {
        coins = 1500;
        //coins = PlayerPrefs.GetInt("Coins", 0);
        coinsText.text = coins.ToString();

        DisplayBatteryInfo();
        DisplayMagnetInfo();
    }

    public void DisplayBatteryInfo()
    {
        string displayText = "Level: " + powerupManager.currentLevelBattery.level + "\n";

        if (powerupManager.currentLevelBattery.nextUpgrade == null)
        {
            batteryUpgradeButton.interactable = false;
            displayText += "Max Level!";
        }
        else
        {
            displayText += "Pay " + powerupManager.currentLevelBattery.upgradeCost + " to upgrade";
        }

        batteryInfoText.text = displayText;
    }

    public void UpgradeBattery()
    {
        if(powerupManager.currentLevelBattery.upgradeCost <= coins)
        {
            coins -= powerupManager.currentLevelBattery.upgradeCost;
            PlayerPrefs.SetInt("Coins", coins);
            coinsText.text = coins.ToString();
            powerupManager.currentLevelBattery = powerupManager.currentLevelBattery.nextUpgrade;
            DisplayBatteryInfo();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void DisplayMagnetInfo()
    {

    }
}
