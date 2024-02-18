using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class OptionsReturnBtn : MonoBehaviour
{
    public Button myButton; // Button to trigger the scene load
    public string sceneToLoad = "Main"; // Name of the scene to load

    void Start()
    {
        if (myButton != null)
        {
            myButton.onClick.AddListener(() => SceneManager.LoadScene(sceneToLoad));
        }
    }
}
