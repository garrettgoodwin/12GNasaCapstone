using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{


    public AudioSource musicOne;
    public AudioSource musicTwo;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(musicTwo.gameObject.activeInHierarchy)
            {
                musicTwo.gameObject.SetActive(false);
                musicOne.gameObject.SetActive(true);
            }
            else if (musicOne.gameObject.activeInHierarchy)
            {
                musicOne.gameObject.SetActive(false);
                musicTwo.gameObject.SetActive(true);
            }
        }

        
    }
}
