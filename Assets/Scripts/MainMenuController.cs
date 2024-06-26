using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime;


    //Added a new call to caoroutine to play trantion

    public void StartStoryMode()
    {
        //SceneManager.LoadScene("StoryMode");  
        StartCoroutine(StartTransitionToScene("StoryMode"));
    }

    public void StartOpeningScene()
    {
        //SceneManager.LoadScene("OpeningScene");
        StartCoroutine(StartTransitionToScene("OpeningScene"));
    }

    public void StartTutorial()
    {
        //SceneManager.LoadScene("Tutorial");\
        StartCoroutine(StartTransitionToScene("Tutorial"));
    }

    public void StartEndlessMode()
    {
        //SceneManager.LoadScene("Main");
        StartCoroutine(StartTransitionToScene("Main"));

    }

    public void OpenOptions()
    {
        //SceneManager.LoadScene("Options");
        StartCoroutine(StartTransitionToScene("Options"));

    }

    public void ToMainMenu()
    {
        //SceneManager.LoadScene("MainMenu");
        StartCoroutine(StartTransitionToScene("MainMenu"));
    }

    IEnumerator StartTransitionToScene(string sceneName)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }


    public void ToGameScene()
    {
        //SceneManager.LoadScene("Main");
        StartCoroutine(StartTransitionToScene("Main"));
    }
}
