using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    public AudioClip background;
    public AudioClip button;
    public AudioClip death1;
    public AudioClip death2;
    public AudioClip platform;
    public AudioClip key;
    public AudioClip koin;
    public AudioClip paus;
    public AudioClip push;
    public AudioClip finish;
    public AudioClip walk;
    public AudioClip win;
    public AudioClip lompat;
    public AudioClip mendarat;
    public AudioClip mendarat2;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(background);
    }

    public void PlaySFX(AudioClip clip)
    {
        if (!SFXSource.mute)
        {
            SFXSource.PlayOneShot(clip);
        }
    }

    public void PlaySFXLoop(AudioClip clip)
    {
        if (!SFXSource.mute)
        {
            SFXSource.clip = clip;
            SFXSource.loop = true;
            SFXSource.Play();
        }
    }

    public void StopSFXLoop()
    {
        SFXSource.loop = false;
        SFXSource.Stop();
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        SFXSource.mute = !SFXSource.mute;
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        SFXSource.volume = volume;
    }

    public float GetMusicVolume()
    {
        return musicSource.volume;
    }

    public float GetSFXVolume()
    {
        return SFXSource.volume;
    }
}
