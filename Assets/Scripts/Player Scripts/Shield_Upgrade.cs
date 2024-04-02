using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Upgrade : MonoBehaviour
{
    public int shield_level;
    public int shieldUpgradeCost = 40;

    [SerializeField] private Animator playerMovementAnims;

    void Start()
    {
        int totalAmount = PlayerPrefs.GetInt("ShieldUpgradeLevel", 0);
    }

    public void OnTextClick()
    {
        int totalAmount = PlayerPrefs.GetInt("ShieldUpgradeLevel", 0);
        totalAmount += 1;
        //updates the "global variable"
        playerMovementAnims.SetBool("shieldUp", true);
        PlayerPrefs.SetInt("ShieldUpgradeLevel", totalAmount);
    }

    void OnMouseDown()
    {
        OnTextClick();
    }
}