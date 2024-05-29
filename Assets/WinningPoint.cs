using UnityEngine;

public class WinningPoint : MonoBehaviour
{
    private GameManager gameManager;

    private bool player1finish = false;
    private bool player2finish = false;

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
            player1finish = true;
            Debug.Log("Player1 entered the winning point.");
            CheckWinCondition();
        }
        else if (other.CompareTag("Player2"))
        {
            player2finish = true;
            Debug.Log("Player2 entered the winning point.");
            CheckWinCondition();
        }

        CheckPlayersStatus();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            player1finish = false;
            Debug.Log("Player1 exited the winning point.");
        }
        else if (other.CompareTag("Player2"))
        {
            player2finish = false;
            Debug.Log("Player2 exited the winning point.");
        }

        CheckPlayersStatus();
    }

    private void CheckWinCondition()
    {
        if (player1finish && player2finish)
        {
            if (gameManager != null && gameManager.Wins())
            {
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
        if (player1finish && !player2finish)
        {
            Debug.Log("Player1 is waiting for Player2 to enter the door.");
        }
        else if (!player1finish && player2finish)
        {
            Debug.Log("Player2 is waiting for Player1 to enter the door.");
        }
    }
}
