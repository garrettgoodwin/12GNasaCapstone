using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private float scoreRate = 100f;
    public int score;

    private bool running = true;

    bool hasStarted = false;

    void Start()
    {
        //StartCoroutine(UpdateScore());

        //PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        //if (playerHealth != null)
        //{
        //    playerHealth.OnPlayerDeath.AddListener(StopTimer);
        //}
    }


    private void Update()
    {
        if(!hasStarted && Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(UpdateScore());
            hasStarted = true;
        }


        //if(!hasStarted)
        //{
        //    if(Input.GetKeyDown(KeyCode.Mouse0))
        //    {
        //        hasStarted = true;
        //    }
        //}

    }

    IEnumerator UpdateScore()
    {
        while(running)
        {
            score += 1;
            scoreText.text = score.ToString("D5") + "M";
            
            yield return new WaitForSeconds(.25f);
        }
        StopTimer();
    }

    public void StopTimer()
    {
        running = false;
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = score.ToString("D5");
    }
}
