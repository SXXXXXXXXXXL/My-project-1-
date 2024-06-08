using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public static bool isPaused = false;

    // Pause the game and show the pause menu
    private void Pause()
    {
        Time.timeScale = 0f; // Pause the game
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    // Resume the game and hide the pause menu
    public void Resume()
    {
        Time.timeScale = 1f; // Unpause the game
        pauseMenu.SetActive(false);
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
}

