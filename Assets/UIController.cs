using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private GameObject audioSettingsPanel;

    private void Start()
    {
        // Initialize sliders with current volume levels
        musicSlider.value = AudioManager.Instance.GetMusicVolume();
        sfxSlider.value = AudioManager.Instance.GetSFXVolume();

        // Add listeners to handle slider value changes
        musicSlider.onValueChanged.AddListener(delegate { SetMusicVolume(); });
        sfxSlider.onValueChanged.AddListener(delegate { SetSFXVolume(); });
    }

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }

    public void SetMusicVolume()
    {
        AudioManager.Instance.SetMusicVolume(musicSlider.value);
    }

    public void SetSFXVolume()
    {
        AudioManager.Instance.SetSFXVolume(sfxSlider.value);
    }

    // Show the Audio Settings panel and pause the player's movement
    public void OpenAudioSettings()
    {
        Time.timeScale = 0f; // Pause the game
        audioSettingsPanel.SetActive(true);
        // Optionally, you can disable player movement here if needed
    }

    // Hide the Audio Settings panel and resume the player's movement
    public void CloseAudioSettings()
    {
        audioSettingsPanel.SetActive(false);
        Time.timeScale = 1f; // Resume the game
        // Optionally, you can enable player movement here if needed
    }
}
