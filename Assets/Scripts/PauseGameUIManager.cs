using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseGameUIManager : MonoBehaviour
{
    [SerializeField] private GameObject levelCompletedeScreen;
    [SerializeField] private string[] endGameMessages = null;


    [SerializeField] private TMP_Text endGameMessageText;

    private void Start()
    {
        DisableEndGameScreen();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (levelCompletedeScreen.activeInHierarchy)
            {
                levelCompletedeScreen.SetActive(false);
                Time.timeScale = 1.0f;
            }
            else
            {
                levelCompletedeScreen.SetActive(true);
                Time.timeScale = 0f;
            }
        }
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
