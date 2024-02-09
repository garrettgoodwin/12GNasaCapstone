using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public static int speedLevel = 1;
    public static int healthLevel = 1;
    public static int shieldLevel = 1;

    public int speedUpgradeCost = 50;
    public int healthUpgradeCost = 30;
    public int shieldUpgradeCost = 40;

    public Text speedText;
    public Text healthText;
    public Text shieldText;

    public Text coinsText;

    void Start()
    {
        UpdateUpgradeUI();
        UpdateCoinsUI();
    }

    void UpdateUpgradeUI()
    {
        Speed.text = "Speed Level: " + speedLevel;
        Health.text = "Health Level: " + healthLevel;
        Shield.text = "Shield Level: " + shieldLevel;
    }

    void UpdateCoinsUI()
    {
        coinsText.text = "Coins: " + GameManager.coins;
    }

    public void UpgradeSpeed()
    {
        if (GameManager.coins >= speedUpgradeCost)
        {
            GameManager.coins -= speedUpgradeCost;
            speedLevel++;

            UpdateUpgradeUI();
            UpdateCoinsUI();
        }
        else
        {
            // Display a message indicating insufficient coins.
            Debug.Log("Insufficient coins for speed upgrade.");
        }
    }

    public void UpgradeHealth()
    {
        if (GameManager.coins >= healthUpgradeCost)
        {
            GameManager.coins -= healthUpgradeCost;
            healthLevel++;
            // Apply health upgrade to the ship.
            UpdateUpgradeUI();
            UpdateCoinsUI();
        }
        else
        {
            // Display a message indicating insufficient coins.
            Debug.Log("Insufficient coins for health upgrade.");
        }
    }

    public void UpgradeShield()
    {
        if (GameManager.coins >= shieldUpgradeCost)
        {
            GameManager.coins -= shieldUpgradeCost;
            shieldLevel++;
            // Apply shield upgrade to the ship.
            UpdateUpgradeUI();
            UpdateCoinsUI();
        }
        else
        {
            // Display a message indicating insufficient coins.
            Debug.Log("Insufficient coins for shield upgrade.");
        }
    }

}