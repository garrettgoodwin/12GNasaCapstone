using UnityEngine;
using UnityEngine.UI;
using TMPro; // For TextMeshPro support
using UnityEngine.Audio; // For AudioMixer

public class SoundControl : MonoBehaviour
{
    public Slider soundSlider; // Assign in the Inspector
    public TextMeshProUGUI soundTextUI; // Assign in the Inspector
    public AudioMixer audioMixer; // Assign your AudioMixer in the Inspector

    private void Start()
    {
        LoadValues();
        soundSlider.onValueChanged.AddListener(HandleSoundLevel); // Subscribe to the slider's value change event
    }

    public void HandleSoundLevel(float level)
    {
        audioMixer.SetFloat("SoundEffectsVol", Mathf.Log10(level) * 20); // Convert slider value to dB
        soundTextUI.text = $"Sound: {level.ToString("P0")}"; // Display as percentage
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat("soundEffectsVolume", soundSlider.value);
    }

    public void LoadValues()
    {
        if (PlayerPrefs.HasKey("soundEffectsVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("soundEffectsVolume");
            soundSlider.value = savedVolume;
            HandleSoundLevel(savedVolume); // Apply the saved volume
        }
        else
        {
            soundSlider.value = 1f; // Default volume
            HandleSoundLevel(1f); // Apply default volume
        }
    }
}
