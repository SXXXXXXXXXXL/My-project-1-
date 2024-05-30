using UnityEngine;

public class CoinMiftahul : MonoBehaviour
{
    private GameManager gameManager;

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
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            if (gameManager != null)
            {
                gameManager.CollectCoin();
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("GameManager reference is null.");
            }
        }
    }
}
