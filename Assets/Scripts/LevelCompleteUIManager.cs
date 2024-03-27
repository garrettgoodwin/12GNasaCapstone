using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCompleteUIManager : MonoBehaviour
{
    [SerializeField] private GameObject levelCompletedeScreen;
    [SerializeField] private string[] endGameMessages = null;


    [SerializeField] private TMP_Text endGameMessageText;

    private void Start()
    {
        DisableEndGameScreen();
    }

    private void DisableEndGameScreen()
    {
        if (levelCompletedeScreen.activeInHierarchy)
        {
            levelCompletedeScreen.SetActive(false);
        }
    }

    public void EnableCompletedLevelScreen()
    {
        if (!levelCompletedeScreen.activeInHierarchy)
        {
            levelCompletedeScreen.SetActive(true);

            if(endGameMessages.Length > 0 && endGameMessageText != null)
            {
                string message = endGameMessages[Random.Range(0, endGameMessages.Length)];
                endGameMessageText.text = message;
            }
        }
    }
}
