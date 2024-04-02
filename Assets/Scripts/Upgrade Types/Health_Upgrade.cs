using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Upgrade : MonoBehaviour
{
    // Game health level is stored in the gameManager script
     public static int health_level = 0;
     // = gameManager.health_level;
    public static int currentHealth;
    // Health upgrade cost
    public int healthUpgradeCost = 30;

    void Start()
    // Start is called before the first frame updatevoid Start()
    {
        currentHealth = health_level;
    }

    void Update()
    {
    }

    public void OnTextClick()
    {
        // Increase speed when the TextMeshPro Text is clicked
        currentHealth = health_level+1;
    }

    void OnMouseDown()
    {
        OnTextClick();
    }
}
