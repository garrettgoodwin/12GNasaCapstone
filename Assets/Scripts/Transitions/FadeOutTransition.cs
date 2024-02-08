using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOutTransition : SceneTransition
{
    public Image fadeOutUIImage;
    public float fadeSpeed = 0.8f;

    public override void InitializeTransition()
    {
        // Start with a transparent image
        fadeOutUIImage.color = new Color(0, 0, 0, 0);
        fadeOutUIImage.gameObject.SetActive(true);
    }

    public override void PerformTransition()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float alpha = 0.0f;
        while (alpha < 1.0f)
        {
            alpha += Time.deltaTime / fadeSpeed;
            fadeOutUIImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }

    public override void EndTransition()
    {
        // Optionally, hide the UI element after transition
        fadeOutUIImage.gameObject.SetActive(false);
    }
}
