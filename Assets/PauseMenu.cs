using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject tutorialMenu; // Referensi untuk menu tutorial
    [SerializeField] GameObject tutorialButton; // Referensi untuk tombol tutorial

    public static bool isPaused = false;

    // Pause the game and show the pause menu
    private void Pause()
    {
        Time.timeScale = 0f; // Pause the game
        pauseMenu.SetActive(true);
        tutorialButton.SetActive(false); // Nonaktifkan tombol tutorial
        isPaused = true;
    }

    // Resume the game and hide the pause menu
    public void Resume()
    {
        Time.timeScale = 1f; // Unpause the game
        pauseMenu.SetActive(false);
        tutorialButton.SetActive(true); // Aktifkan kembali tombol tutorial
        isPaused = false;
    }

    // Return to the main menu
    public void Home()
    {
        Time.timeScale = 1f; // Unpause the game before leaving the scene
        SceneManager.LoadScene("Main Menu");
        isPaused = false;
    }

    // Restart the current scene
    public void Restart()
    {
        Time.timeScale = 1f; // Unpause the game before restarting the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isPaused = false;
    }

    // Show the tutorial menu and pause the game
    public void ShowTutorial()
    {
        Time.timeScale = 0f; // Pause the game
        tutorialMenu.SetActive(true);
        tutorialButton.SetActive(false); // Nonaktifkan tombol tutorial
        isPaused = true;
    }

    // Hide the tutorial menu and resume the game
    public void HideTutorial()
    {
        Time.timeScale = 1f; // Unpause the game
        tutorialMenu.SetActive(false);
        tutorialButton.SetActive(true); // Aktifkan kembali tombol tutorial
        isPaused = false;
    }
}
