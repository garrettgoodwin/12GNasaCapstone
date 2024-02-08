using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public SceneTransition currentTransition;

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(TransitionToScene(sceneName));
    }

    private IEnumerator TransitionToScene(string sceneName)
    {
        currentTransition.InitializeTransition();
        yield return new WaitForSeconds(1f);
        currentTransition.PerformTransition();
        
        SceneManager.LoadScene(sceneName);

        currentTransition.EndTransition();
    }
}
