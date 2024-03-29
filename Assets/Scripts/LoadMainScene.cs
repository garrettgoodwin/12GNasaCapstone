using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadMainScene : MonoBehaviour
{
    public float cutsceneDuration = 55f; 

    void Start()
    {
        //auto load main scene
        Invoke("LoadMain", cutsceneDuration);
    }

    public void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }
}