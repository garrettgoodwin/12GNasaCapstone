using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlinkingText : MonoBehaviour
{

    [SerializeField] private GameObject textToBlink;
    [SerializeField] private float blinkInterval;


    [SerializeField] private MainMenuController sceneController;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlyBlinkText());
    }

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            sceneController.ToMainMenu();
        }
    }

    IEnumerator RepeatedlyBlinkText()
    {

        while (true)
        {
            textToBlink.SetActive(!textToBlink.activeInHierarchy);
            yield return new WaitForSeconds(blinkInterval);
        }
    }



}
