using UnityEngine;

public class Key : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.KeyCollected(); // Memanggil method di GameManager
            Destroy(gameObject); // kunci ilang setelah diambil
        }
    }
}
