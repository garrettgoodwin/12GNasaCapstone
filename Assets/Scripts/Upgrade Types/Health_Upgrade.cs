using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Upgrade : MonoBehaviour
{
    public int health_level;
    public int healthUpgradeCost = 30;

    void Start()
    {
        int totalAmount = PlayerPrefs.GetInt("HealthUpgradeLevel", 0);
    }

    public void OnTextClick()
    {
        // Increase speed when the TextMeshPro Text is clicked
        int totalAmount = PlayerPrefs.GetInt("HealthUpgradeLevel", 0);
        totalAmount += 1;
        PlayerPrefs.SetInt("HealthUpgradeLevel", totalAmount);
    }

    void OnMouseDown()
    {
        OnTextClick();
    }
}