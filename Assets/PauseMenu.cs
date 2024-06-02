using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    // Pause the game and show the pause menu
    public void Pause()
    {
        Time.timeScale = 0f; // Pause the game
        pauseMenu.SetActive(true);
    }

    // Return to the main menu
    public void Home()
    {
        Time.timeScale = 1f; // Unpause the game before leaving the scene
        SceneManager.LoadScene("Main Menu");
    }

    // Resume the game and hide the pause menu
    public void Resume()
    {
        Time.timeScale = 1f; // Unpause the game
        pauseMenu.SetActive(false);
    }

    // Restart the current scene
    public void Restart()
    {
        Time.timeScale = 1f; // Unpause the game before restarting the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
