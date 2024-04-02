using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Upgrade : MonoBehaviour
{
    // public static int shield_level = gameManager.shield_level;

    public static int currentShield;
    public int shieldUpgradeCost = 40;
    void Start()
    // Start is called before the first frame updatevoid Start()
    {
        currentShield = 10;
    }

    void Update()
    {
    }

    public void OnTextClick()
    {
        // Increase speed when the TextMeshPro Text is clicked
        currentShield = 20;
    }

    void OnMouseDown()
    {
        OnTextClick();
    }
}
