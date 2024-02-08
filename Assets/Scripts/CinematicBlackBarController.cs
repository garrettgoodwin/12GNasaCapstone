using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CinematicBlackBarController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool hasHiddenBars = false;
    public TMP_Text startText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !hasHiddenBars)
        {
            HideBlackBars();
            hasHiddenBars = true; // Set the flag to true after hiding bars
            startText.text = "";
        }
    }

    public void ShowBlackBars()
    {
        if (animator.GetBool("removeBars") != false)
        {
            animator.SetBool("removeBars", false);
            hasHiddenBars = false; // Reset the flag if bars are shown again
        }
    }

    public void HideBlackBars()
    {
        if (animator.GetBool("removeBars") != true)
        {
            animator.SetBool("removeBars", true);
        }
    }
}
