using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Add this namespace for TextMeshPro

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider = null; // Assign in the inspector
    public TextMeshProUGUI volumeTextUI = null; // Assign in the inspector

    void Start()
    {
        LoadValues();
        volumeSlider.onValueChanged.AddListener(VolumeSlider); // Add listener for the slider
    }

    public void VolumeSlider(float volume)
    {
        volumeTextUI.text = volume.ToString("P1"); // P1 format for percentage
        AudioListener.volume = volume; // Directly set the volume
    }

    public void SaveVolumeButton()
    {
        PlayerPrefs.SetFloat("volumeValue", volumeSlider.value);
        LoadValues();
    }

    public void LoadValues()
    {
        if (PlayerPrefs.HasKey("volumeValue"))
        {
            float volumeValue = PlayerPrefs.GetFloat("volumeValue");
            volumeSlider.value = volumeValue;
            VolumeSlider(volumeValue); // Ensure the text and volume are updated on load
        }
        else
        {
            // Optional: Set a default volume if no preference is saved
            volumeSlider.value = 0.5f; // Default volume
            VolumeSlider(0.5f); // Update the text and set the volume
        }
    }
}
