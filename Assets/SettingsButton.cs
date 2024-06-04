using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel; // Reference to the settings panel

    // Method to show the settings panel and pause the game
    public void OpenSettings()
    {
        Time.timeScale = 0f; // Pause the game
        settingsPanel.SetActive(true); // Show the settings panel
    }

    // Method to hide the settings panel and resume the game
    public void CloseSettings()
    {
        settingsPanel.SetActive(false); // Hide the settings panel
        Time.timeScale = 1f; // Resume the game
    }
}
