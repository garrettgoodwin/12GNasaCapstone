using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButtonController : MonoBehaviour
{
    public GameObject gameObjectA;
    public GameObject gameObjectB;


    private void Start()
    {
        gameObjectA.SetActive(true);
        gameObjectB.SetActive(true);

    }


    // Call this method when the first button is clicked
    public void ToggleOnFirstButton()
    {
        gameObjectA.SetActive(true);
        gameObjectB.SetActive(false);
    }

    // Call this method when the second button is clicked
    public void ToggleOnSecondButton()
    {
        gameObjectA.SetActive(false);
        gameObjectB.SetActive(true);
    }
}
