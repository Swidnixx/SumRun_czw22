using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;


public class Shop : MonoBehaviour
{
    public Immortality battery;
    public Magnet magnet;

    public Text coinsText;
    int coins;

    public Text batteryInfoText;
    public Text magnetInfoText;

    public Button batteryUpgradeButton;

    private void Start()
    {
        coins = PlayerPrefs.GetInt("Coins", 0);
        coinsText.text = coins.ToString();

        DisplayBatteryInfo();
        DisplayMagnetInfo();
    }

    public void DisplayBatteryInfo()
    {
        string displayText = "Level: " + battery.level + "\n";

        if (battery.nextUpgrade == null)
        {
            batteryUpgradeButton.interactable = false;
            displayText += "Max Level!";
        }
        else
        {
            displayText += "Pay " + battery.upgradeCost + " to upgrade";
        }

        batteryInfoText.text = displayText;
    }

    public void DisplayMagnetInfo()
    {

    }
}
