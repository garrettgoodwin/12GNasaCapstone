using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    private PlayerMovement playerMovement;
    private PlayerBank playerBank;
    private PlayerHealth playerHealth;

    void Start()
    {
        InitializeComponents();
    }

    void InitializeComponents()
    {
        playerMovement = GetComponent<PlayerMovement>();
                
        playerHealth = GetComponent<PlayerHealth>();

        if (playerMovement == null)
        {
            Debug.LogError("Player Movement Component is not assigned in Player script");
        }
        if(playerHealth == null)
        {
            Debug.LogError("Player Health Component is not assigned in Player script"); ;
        }
    }
}
