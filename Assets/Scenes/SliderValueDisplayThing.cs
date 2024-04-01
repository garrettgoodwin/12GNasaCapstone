using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderValueDisplayThing : MonoBehaviour
{
    public Slider slider; // Reference to your slider
    public TMP_Text displayText; // Reference to your text element

    void Start()
    {
        if (slider != null)
        {
            // Add a listener to call the OnSliderValueChanged method whenever the slider value changes
            slider.onValueChanged.AddListener(OnSliderValueChanged);

            // Initialize the text with the current value
            OnSliderValueChanged(slider.value);
        }
    }

    // This method will be called whenever the slider value changes
    private void OnSliderValueChanged(float value)
    {
        if (displayText != null)
        {
            // Convert the float value to an integer between 0 and 100
            int intValue = Mathf.RoundToInt(value * 100); // Assuming the slider's value range is 0 to 1

            // Update the display text to show the current integer value
            displayText.text = intValue.ToString();
        }
    }
}
