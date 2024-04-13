using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempClickScript : MonoBehaviour
{

    [SerializeField] private MainMenuController mainMenuController;
    // Start is called before the first frame update
    void Start()
    {
     

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            mainMenuController.ToTempMainMenu();
        }
    }
}
