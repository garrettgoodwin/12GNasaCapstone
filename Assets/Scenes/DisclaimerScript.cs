using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisclaimerScript : MonoBehaviour
{
    [SerializeField] private GameObject endGammeScreen;

    private void Start()
    {
        DisableEndGameScreen();
    }

    public void DisableEndGameScreen()
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
        }
    }


}
