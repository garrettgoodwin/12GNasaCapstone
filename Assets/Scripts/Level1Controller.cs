using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Level1Controller : MonoBehaviour
{
    [SerializeField] private float timeToCompleteLevel;

    public UnityEvent OnPlayerCompletedLevel;

    private Coroutine countdownCoroutine;

    private void Start()
    {
        if (timeToCompleteLevel > 0)
        {
            countdownCoroutine = StartCoroutine(LevelCountdown());
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
            OnPlayerCompletedLevel?.Invoke();
    }

    void StopCoroutineTimer()
    {
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }
        Debug.Log("Player has died");
        // Add any additional logic needed when the player dies
    }

    void RestartLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
