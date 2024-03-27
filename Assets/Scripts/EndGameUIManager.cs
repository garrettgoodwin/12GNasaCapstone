using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameUIManager : MonoBehaviour
{
    [SerializeField] private GameObject endGammeScreen;
    [SerializeField] private GameObject endGammeScreenLeaderBoard;
    [SerializeField] private string[] endGameMessages = null;


    [SerializeField] private TMP_Text endGameMessageText;

    private void Start()
    {
        DisableEndGameScreen();
    }

    private void DisableEndGameScreen()
    {
        if (endGammeScreen.activeInHierarchy)
        {
            endGammeScreen.SetActive(false);
        }
    }

    public void EnableEndGameScreen()
    {
        if (!endGammeScreen.activeInHierarchy)
        {

            endGammeScreen.SetActive(true);
            DisableEndGameScreenLeaderBoard();

            if(endGameMessages.Length > 0 && endGameMessageText != null)
            {
                string message = endGameMessages[Random.Range(0, endGameMessages.Length)];
                endGameMessageText.text = message;
            }
        }
    }

    public void EnableEndGameScreenLeaderBoard()
    {
        Debug.Log("Clicked the button");

        if (!endGammeScreenLeaderBoard.activeInHierarchy)
        {
            endGammeScreenLeaderBoard.SetActive(true);
            DisableEndGameScreen();
        }
    }

    public void DisableEndGameScreenLeaderBoard()
    {
        if (endGammeScreenLeaderBoard.activeInHierarchy)
        {
            endGammeScreenLeaderBoard.SetActive(false);
        }
    }


}
