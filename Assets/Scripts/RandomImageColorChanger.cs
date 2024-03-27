using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required namespace for Image

public class RandomImageColorChanger : MonoBehaviour
{
    [SerializeField] private Image image; // Reference to the Image component
    [SerializeField] private Color[] colors;

    void Start()
    {
        if (image != null)
        {
            ChangeImageColor();
        }
        else
        {
            Debug.LogError("Image was not assigned to RandomImageColorChanger on " + gameObject.name);
        }
    }

    void ChangeImageColor()
    {
        if (colors.Length > 0)
        {
            int index = Random.Range(0, colors.Length);
            image.color = colors[index]; // Apply the color to the Image component
        }
        else
        {
            Debug.LogError("No Colors are assigned in the array for RandomImageColorChanger on " + gameObject.name);
        }
    }
}