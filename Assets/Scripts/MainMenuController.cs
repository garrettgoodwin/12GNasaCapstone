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
        SceneManager.LoadScene("StoryMode");  
    }

    public void StartOpeningScene()
    {
        SceneManager.LoadScene("OpeningScene");
    }

    public void StartTutorial()
    {
        SceneManager.LoadScene("Tutorial");  
    }

    public void StartEndlessMode()
    {
//        SceneManager.LoadScene("EndlessMode");
        SceneManager.LoadScene("Main");

    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("Options");  
    }

    public void ToMainMenu()
    {
        StartCoroutine(TransitionPlay());
    }

    IEnumerator TransitionPlay()
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("MainMenu");
    }


    public void ToGameScene()
    {
        SceneManager.LoadScene("Main");
    }
}
