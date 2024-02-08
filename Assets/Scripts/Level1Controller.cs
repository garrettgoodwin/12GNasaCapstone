using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Controller : MonoBehaviour
{
    [SerializeField] private float timeToCompleteLevel;

    [SerializeField] Player player;


    void Start()
    {
        if(player != null)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            
            if(playerHealth != null)
            {
                playerHealth.OnPlayerDeath.AddListener(RestartLevel);
            }
            else
            {
                Debug.LogWarning("PlayerHealth local variable is not found in the Level1Controller script");
            }
        }
        else
        {
            Debug.LogWarning("Player reference is not assigned in the Level1Controller script");
        }

        if(timeToCompleteLevel > 0)
        {
            StartCoroutine(LevelCountdown());
        }
        else
        {
            Debug.LogWarning("timeToCompleteLevel has not been assigned in the Unity Editor");
        }
    }

    IEnumerator LevelCountdown()
    {
        yield return new WaitForSeconds(timeToCompleteLevel);
        LevelCompleted();
    }

    void LevelCompleted()
    {
        Debug.Log("Finished this");
    }

    //I dont think that this should go here
    void RestartLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
