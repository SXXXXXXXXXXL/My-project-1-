using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Make sure to include this if using UI elements like Slider and Button

public class SoundManager : MonoBehaviour
{
    public Slider volumeSlider; // Reference to the volume slider UI element
    public Button muteButton; // Reference to the mute button UI element

    private bool isMuted = false; // Variable to store mute state

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1f);
            PlayerPrefs.SetInt("isMuted", 0);
            Load();
        }
        else
        {
            Load();
        }

        volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
        muteButton.onClick.AddListener(delegate { ToggleMute(); });
    }

    public void ChangeVolume()
    {
        if (!isMuted)
        {
            AudioListener.volume = volumeSlider.value;
            Save();
        }
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        if (isMuted)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = volumeSlider.value;
        }
        SaveMuteState();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        isMuted = PlayerPrefs.GetInt("isMuted") == 1;
        if (isMuted)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = volumeSlider.value;
        }
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    private void SaveMuteState()
    {
        PlayerPrefs.SetInt("isMuted", isMuted ? 1 : 0);
    }
}
