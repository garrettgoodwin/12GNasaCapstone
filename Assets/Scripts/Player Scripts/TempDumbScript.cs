using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempDumbScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {


            // Get the current scene name
            string sceneName = SceneManager.GetActiveScene().name;

            SceneManager.LoadScene(sceneName);

        }

    }
}
