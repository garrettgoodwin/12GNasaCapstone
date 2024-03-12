using UnityEngine;
using System.Collections;

public class DelayedAudioPlayer : MonoBehaviour
{
    // Separate variables for each audio track and delay
    public AudioClip audioTrack1;
    public float delay1;
    public AudioClip audioTrack2;
    public float delay2;
    public AudioClip audioTrack3;
    public float delay3;
    public AudioClip audioTrack4;
    public float delay4;
    public AudioClip audioTrack5;
    public float delay5;

    private void Start()
    {
        // Start each coroutine to play the tracks after their respective delays
        StartCoroutine(PlayTrackAfterDelay(audioTrack1, delay1));
        StartCoroutine(PlayTrackAfterDelay(audioTrack2, delay2));
        StartCoroutine(PlayTrackAfterDelay(audioTrack3, delay3));
        StartCoroutine(PlayTrackAfterDelay(audioTrack4, delay4));
        StartCoroutine(PlayTrackAfterDelay(audioTrack5, delay5));
    }

    private IEnumerator PlayTrackAfterDelay(AudioClip clip, float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Play the track if it's assigned
        if (clip != null)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.Play();

            // Optionally, destroy the AudioSource component after the clip finishes playing if you don't need it anymore
            Destroy(audioSource, clip.length);
        }
    }
}
