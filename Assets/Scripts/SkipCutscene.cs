using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipCutscene : MonoBehaviour
{
    public string sceneToLoad = "MainScene"; // Name of the scene to load after skipping

    // Call this method when the skip button is clicked
    public void SkipToScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}