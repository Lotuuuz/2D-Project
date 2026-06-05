using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource sourceA;
    [SerializeField] private AudioSource sourceB;

    [Header("Music Clips")]
    [SerializeField] private AudioClip normalMusic;
    [SerializeField] private AudioClip chaseMusic;

    [Header("Settings")]
    [SerializeField] private float fadeDuration = 1.5f;

    private AudioSource currentSource;
    private AudioSource inactiveSource;

    private Coroutine fadeCoroutine;

    private void Start()
    {
        currentSource = sourceA;
        inactiveSource = sourceB;

        currentSource.clip = normalMusic;
        currentSource.volume = 0.125f;
        currentSource.Play();

        inactiveSource.volume = 0f;
    }

    public void PlayNormalMusic()
    {
        ChangeMusic(normalMusic);
    }

    public void PlayChaseMusic()
    {
        ChangeMusic(chaseMusic);
    }

    private void ChangeMusic(AudioClip newClip)
    {
        if (currentSource.clip == newClip)
            return;

        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(Crossfade(newClip));
    }

    private IEnumerator Crossfade(AudioClip newClip)
    {
        inactiveSource.clip = newClip;
        inactiveSource.volume = 0f;
        inactiveSource.Play();

        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;

            float t = Mathf.Clamp01(time / fadeDuration);

            currentSource.volume = 0.125f - t;
            inactiveSource.volume = t;

            yield return null;
        }

        currentSource.Stop();
        currentSource.volume = 0f;

        inactiveSource.volume = 0.125f;

        AudioSource temp = currentSource;
        currentSource = inactiveSource;
        inactiveSource = temp;

        fadeCoroutine = null;
    }

    public void FadeOutAndStop()
    {
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float startVolume = currentSource.volume;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;

            currentSource.volume =
                Mathf.Lerp(startVolume, 0f, time / fadeDuration);

            yield return null;
        }

        currentSource.Stop();
        currentSource.volume = startVolume;

        fadeCoroutine = null;
    }


}

