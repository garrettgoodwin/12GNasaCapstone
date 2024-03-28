using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMC : MonoBehaviour
{
    [SerializeField] private GameObject[] gameModeObjects; // Assign your game mode GameObjects here
    private int currentGameModeIndex = 0;
    private float modeChangeInterval = 30f; // Time in seconds to switch between modes
    private float modeChangeTimer;

    void Start()
    {
        ActivateGameMode(currentGameModeIndex);
        modeChangeTimer = modeChangeInterval;
    }

    void Update()
    {
        // Timer to switch game modes
        modeChangeTimer -= Time.deltaTime;
        if (modeChangeTimer <= 0)
        {
            currentGameModeIndex = (currentGameModeIndex + 1) % gameModeObjects.Length;
            ActivateGameMode(currentGameModeIndex);
            modeChangeTimer = modeChangeInterval;
        }
    }

    private void ActivateGameMode(int index)
    {
        // Deactivate all game mode objects
        foreach (var mode in gameModeObjects)
        {
            mode.SetActive(false);
        }

        // Activate the current game mode object
        if (index >= 0 && index < gameModeObjects.Length)
        {
            gameModeObjects[index].SetActive(true);
        }
    }

}
