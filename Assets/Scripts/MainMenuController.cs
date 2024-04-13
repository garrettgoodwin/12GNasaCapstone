using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime;

    public void StartStoryMode()
    {
        StartCoroutine(StartTransitionToScene("StoryMode"));
    }

    public void StartOpeningScene()
    {
        StartCoroutine(StartTransitionToScene("OpeningScene"));
    }

    public void StartTutorial()
    {
        StartCoroutine(StartTransitionToScene("Tutorial"));
    }

    public void StartEndlessMode()
    {
        StartCoroutine(StartTransitionToScene("EndlessMode"));
    }

    public void OpenOptions()
    {
        StartCoroutine(StartTransitionToScene("Options"));
    }

    public void OpenTempOptions()
    {
        StartCoroutine(StartTransitionToScene("Options2"));
    }

    public void OpenUpgradeShop()
    {
        StartCoroutine(StartTransitionToScene("StoreScene"));
    }

    public void ToMainMenu()
    {
        StartCoroutine(StartTransitionToScene("MainMenu"));
    }

    public void ToTempMainMenu()
    {
        StartCoroutine(StartTransitionToScene("MainMenu2"));
    }

    IEnumerator StartTransitionToScene(string sceneName)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }

    public void ToGameScene()
    {
        StartCoroutine(StartTransitionToScene("Main"));
    }

    public void ToQuizScene()
    {
        StartCoroutine(StartTransitionToScene("QuizScene"));
    }

    public void ToLevelOne()
    {
        StartCoroutine(StartTransitionToScene("Level1"));
    }

    public void ToLevelTwo()
    {
        StartCoroutine(StartTransitionToScene("Level12"));
    }

    public void ToLevelThree()
    {
        StartCoroutine(StartTransitionToScene("Level3"));
    }

    public void ToLevelFour()
    {
        StartCoroutine(StartTransitionToScene("Level4"));
    }

    public void ToCreditsPage()
    {
        StartCoroutine(StartTransitionToScene("Credits"));
    }
}
