using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// This handles the behavior of switching and playing audio tracks
/// </summary>
public class AudioHandlerBehavior : MonoBehaviour
{
    /// <summary>
    /// Enum for the type of music to be played
    /// </summary>
    public enum MusicType
    { 
        Lofi,
        Epic,
        Boss
    }

    /// <summary>
    /// Lofi track audio source
    /// </summary>
    public AudioSource LofiAudio;

    /// <summary>
    /// Boss track audio source
    /// </summary>
    public AudioSource BossAudio;

    /// <summary>
    /// Epic track audio source
    /// </summary>
    public AudioSource EpicAudio;


    /// <summary>
    /// Stores the current audio source
    /// </summary>
    private AudioSource currentAudio;

    /// <summary>
    /// Stores the FadeOut Coroutine
    /// </summary>
    private Coroutine cachedFadeOut;
    /// <summary>
    /// Stores the FadeIn Coroutine
    /// </summary>
    private Coroutine cachedFadeIn;

    /// <summary>
    /// Sets intial audio source and sets all audio sources to loop
    /// </summary>
    public void Start()
    {
        currentAudio = EpicAudio;
        EpicAudio.loop = true;
        LofiAudio.loop = true;
        BossAudio.loop = true;
        EpicAudio.Play();
    }

    /// <summary>
    /// Handles switching audio sources
    /// </summary>
    /// <param name="musicType"> This param dictates which audio track to switch to</param>
    public void SwitchMusic(MusicType musicType)
    {
        if (cachedFadeIn != null) StopCoroutine(cachedFadeIn);
        if (cachedFadeOut != null) StopCoroutine(cachedFadeOut);

        switch (musicType)
        {
            case MusicType.Epic:
                SwitchToEpic();
                break;
            case MusicType.Lofi:

                if (currentAudio != LofiAudio)
                {
                    SwitchToLofi();
                }

                break;
            case MusicType.Boss:
                SwitchToBoss();
                break;
        }
    }

    /// <summary>
    /// Switches to Lofi audio source
    /// </summary>
    private void SwitchToLofi()
    {
        cachedFadeOut = StartCoroutine(FadeOut(currentAudio, 0.5f));
        cachedFadeIn = StartCoroutine(FadeIn(LofiAudio, 5.0f));
        currentAudio = LofiAudio;
    }

    /// <summary>
    /// Switches to Boss audio source
    /// </summary>
    private void SwitchToBoss()
    {
        cachedFadeOut =  StartCoroutine(FadeOut(currentAudio, 0.5f));
        cachedFadeIn = StartCoroutine(FadeIn(BossAudio, 5.0f));
        currentAudio = BossAudio;
    }

    /// <summary>
    /// Switches to Epic audio source
    /// </summary>
    private void SwitchToEpic()
    {
        cachedFadeOut = StartCoroutine(FadeOut(currentAudio, 0.5f));
        cachedFadeIn = StartCoroutine(FadeIn(EpicAudio, 5.0f));
        currentAudio = EpicAudio;
    }

    /// <summary>
    /// Handles fade out of current audio source
    /// </summary>
    /// <param name="audioSource"> Takes in current audio source</param>
    /// <param name="FadeTime">Takes in the time to fade out</param>
    /// <returns></returns>
    private static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = 1f;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    /// <summary>
    /// Handles fade in of new audio source
    /// </summary>
    /// <param name="audioSource">Takes in new audio source</param>
    /// <param name="FadeTime">Takes in time to fade in</param>
    /// <returns></returns>
    private static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        float startVolume = 1f;

        audioSource.volume = 0;
        audioSource.Play();

        while (audioSource.volume < 1.0f)
        {
            audioSource.volume += startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.volume = 1f;
    }
}
