using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WinningPointMiftahul : MonoBehaviour
{
    private GameManager gameManager;

    private bool player1Inside = false;
    private bool player2Inside = false;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            player1Inside = true;
            Debug.Log("Player1 entered the winning point.");
            CheckWinCondition();
        }
        else if (other.CompareTag("Player2"))
        {
            player2Inside = true;
            Debug.Log("Player2 entered the winning point.");
            CheckWinCondition();
        }

        CheckPlayersStatus();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            player1Inside = false;
            Debug.Log("Player1 exited the winning point.");
        }
        else if (other.CompareTag("Player2"))
        {
            player2Inside = false;
            Debug.Log("Player2 exited the winning point.");
        }

        CheckPlayersStatus();
    }

    private void CheckWinCondition()
    {
        if (player1Inside && player2Inside)
        {
            if (gameManager != null && gameManager.Wins())
            {
                audioManager.PlaySFX(audioManager.finish);
                StartCoroutine(PlayWinSFX());
                StartCoroutine(NextScene());
                Debug.Log("You win! Door is opening...");
            }
            else
            {
                Debug.Log("Collect all items to open the door.");
            }
        }
    }

    private void CheckPlayersStatus()
    {
        if (player1Inside && !player2Inside)
        {
            Debug.Log("Player1 is waiting for Player2 to enter the door.");
        }
        else if (!player1Inside && player2Inside)
        {
            Debug.Log("Player2 is waiting for Player1 to enter the door.");
        }
    }

    IEnumerator PlayWinSFX()
    {
        yield return new WaitForSeconds(1);
        audioManager.PlaySFX(audioManager.win);
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(2);
        SceneController.instance.NextLevel();
    }
}
