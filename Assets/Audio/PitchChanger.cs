using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchChanger : MonoBehaviour
{
    [SerializeField] private float minPitch = 0.5f;
    [SerializeField] private float maxPitch = 2.0f;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Optionally check if AudioSource exists
        if (audioSource == null)
        {
            Debug.LogWarning("RandomPitchChanger: No AudioSource found on the GameObject.");
        }
    }

    void OnEnable()
    {
        if (audioSource != null)
        {
            audioSource.pitch = Random.Range(minPitch, maxPitch);
        }
    }
}
