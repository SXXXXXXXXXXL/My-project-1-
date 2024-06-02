using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameManager gameManager;
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
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            if (gameManager != null)
            {
                audioManager.PlaySFX(audioManager.koin);
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
