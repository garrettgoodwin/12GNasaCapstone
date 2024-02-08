using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreManager : MonoBehaviour
{
    public TMP_Text highscoreText;
    private void Start()
    {
        LoadValues();
    }

    //MAIN CANVAS
    //COMPONENTS WOULD BE SCORE MANAGER
    //HIGH SVORE MANAGER

    public void LoadValues()
    {
        int highscoreValue;

        if (!PlayerPrefs.HasKey("HighScore"))
            PlayerPrefs.SetInt("HighScore", 0);
        highscoreValue = PlayerPrefs.GetInt("HighScore");

        highscoreText.text = highscoreValue.ToString("D5");
    }

    public void SetNewHighscore()
    {

    }


}
