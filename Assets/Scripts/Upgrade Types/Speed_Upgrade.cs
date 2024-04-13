using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_Upgrade : MonoBehaviour
{
    public int speedLevel;
    public int speedUpgradeCost = 50;

    void Start()
    {
        int totalAmount = PlayerPrefs.GetInt("SpeeedUpgradeLevel", 0);
    }

    public void OnTextClick()
    {
        int totalAmount = PlayerPrefs.GetInt("SpeeedUpgradeLevel", 0);
        totalAmount += 1;
        PlayerPrefs.SetInt("SpeeedUpgradeLevel", totalAmount);
    }

    void OnMouseDown()
    {
        OnTextClick();
    }
}
