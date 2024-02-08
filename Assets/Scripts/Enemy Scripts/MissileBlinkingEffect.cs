using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBlinkingEffect : MonoBehaviour
{
    public float startInterval = 1.0f; // Starting interval between blinks
    public float minInterval = 0.1f; // Minimum interval between blinks
    public float decreaseFactor = 0.9f; // Factor by which the interval decreases each time

    public GameObject WhatNeedsToBlink;
    public GameObject WhatNeedsToBlink2;
    public GameObject parentOBJNow;

    public GameObject soundEggectTest;


    void Start()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        float currentInterval = startInterval;

        while (currentInterval > minInterval)
        {
            // Toggle active state
            if(WhatNeedsToBlink.activeInHierarchy)
            {
                WhatNeedsToBlink.SetActive(false);
                //WhatNeedsToBlink2.SetActive(true);

            }
            else
            {
                WhatNeedsToBlink.SetActive(true);
            }

            // Wait for the current interval
            yield return new WaitForSeconds(currentInterval);

            // Decrease the interval
            currentInterval *= decreaseFactor;
        }

        if(currentInterval <= minInterval)
        {
            WhatNeedsToBlink.SetActive(true);
            yield return new WaitForSeconds(.4f);

            CameraShaker.Instance.ShakeOnce(2.5f, 4f, .1f, 1f);
            Instantiate(soundEggectTest, gameObject.transform.position, Quaternion.identity);
            Destroy(parentOBJNow);
        }
    }
}
