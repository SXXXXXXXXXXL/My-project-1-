using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.CoinCollected();
            // Coin ilang setelah diambil
            Destroy(gameObject);
        }
    }
}