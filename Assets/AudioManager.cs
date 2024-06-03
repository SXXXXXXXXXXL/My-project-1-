using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

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

    private void Start()
    {
        //musicSource.clip = background;
        //musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlaySFXLoop(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

}
