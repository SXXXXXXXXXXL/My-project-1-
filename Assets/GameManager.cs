using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalCoins; // Input total koin pada scene
    public GameObject key;

    private int coinsCollected = 0; // Jumlah koin yang dikumpul

    void Start()
    {
        key.SetActive(false); // Utk menyembunyikan kunci sebelum koin terkumpul
    }

    public void CoinCollected()
    {
        coinsCollected++; // Increment setiap koin diambil

        if (coinsCollected == totalCoins) // Kondisi jika setiap koin terkumpul
        {
            // Spawn kunci
            key.SetActive(true);
        }
    }
    public void KeyCollected()
    {
        Debug.Log("Key collected!");
    }
}