using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    public static MusicController Instance { get; private set; }

    public AudioSource audioSource;
    public AudioClip[] musicTracks;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AudioClip sceneMusic = null;
        float fadeDuration = 1;

        switch (scene.buildIndex)
        {
            //Opening Sccene
            case 0:
                fadeDuration = 0.1f;
                sceneMusic = musicTracks[0];
                break;

            //Main Menu
            case 1:
                fadeDuration = 0.5f;
                sceneMusic = musicTracks[0];
                break;

            //Endless Mode
            case 2:
                fadeDuration = 0.4f;
                sceneMusic = musicTracks[0];
                break;

            //Level 1
            case 3:
                fadeDuration = 0.75f;
                sceneMusic = musicTracks[1];
                break;

            //Level 2
            case 4:
                fadeDuration = 0.75f;
                sceneMusic = musicTracks[1];
                break;

            //Level 3
            case 5:
                fadeDuration = 0.75f;
                sceneMusic = musicTracks[1];
                break;

            default:
                // Handle other scenes or do nothing
                break;
        }

        if (sceneMusic != null && audioSource.clip != sceneMusic)
        {
            PlayMusicWithFade(sceneMusic, fadeDuration);
        }
    }

    public void PlayMusicWithFade(AudioClip newClip, float duration)
    {
        StartCoroutine(FadeOutIn(audioSource, newClip, duration));
    }

    private IEnumerator FadeOutIn(AudioSource source, AudioClip newClip, float duration)
    {
        float currentTime = 0;
        float startVolume = source.volume;

        // Fade out
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            source.volume = Mathf.Lerp(startVolume, 0, currentTime / duration);
            yield return null;
        }

        source.Stop();
        source.clip = newClip;
        source.Play();

        // Fade in
        currentTime = 0;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            source.volume = Mathf.Lerp(0, startVolume, currentTime / duration);
            yield return null;
        }
    }

    private void OnDestroy()
    {
        // Clean up the event listener when the music controller is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
