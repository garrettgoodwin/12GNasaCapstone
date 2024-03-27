using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlinkingText : MonoBehaviour
{
    [SerializeField] private GameObject textToBlink;
    [SerializeField] private float blinkInterval = .35f;
    private bool isBlinking = false;
    private Coroutine blinkCoroutine;

    void Start()
    {
        StartBlinking();
    }

    private void Update()
    {
        if(Input.anyKey)
        {
            StopBlinking();
        }
    }

    public void StartBlinking()
    {
        if (!isBlinking)
        {
            isBlinking = true;
            blinkCoroutine = StartCoroutine(RepeatedlyBlinkText());
        }
    }

    public void StopBlinking()
    {
        if (isBlinking && blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
            isBlinking = false;
            textToBlink.SetActive(false);
            Destroy(gameObject);
        }
    }

    IEnumerator RepeatedlyBlinkText()
    {
        while (isBlinking)
        {
            textToBlink.SetActive(!textToBlink.activeInHierarchy);
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
