using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpriteColorChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color[] colors;

    void Start()
    {
        if(spriteRenderer != null)
        {
            ChangeSpriteColor();
        }
        else
        {
            Debug.LogError("SpriteRenderer was not assigned to RandomSpriteColorChanger on " + gameObject.name);
        }
    }

    void ChangeSpriteColor()
    {
        if(colors.Length > 0)
        {
            int index = Random.Range(0, colors.Length);
            spriteRenderer.color = colors[index];
        }
        else
        {
            Debug.LogError("No Colors are assigned in the array for RandomSpriteColorChanger on " + gameObject.name);
        }
    }
}
