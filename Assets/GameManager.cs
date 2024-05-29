using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalCoins; // Total number of coins in the level
    private int collectedCoins = 0; // Number of coins collected so far
    private bool keyCollected = false; // Whether the key has been collected

    public GameObject key; // Reference to the key GameObject

    private void Start()
    {
        if (key != null)
        {
            key.SetActive(false); // Ensure the key is inactive at the start
        }
        else
        {
            Debug.LogError("Key GameObject reference not set in GameManager.");
        }
    }

    public void CollectCoin()
    {
        collectedCoins++;
        CheckWinCondition();
    }

    public void CollectKey()
    {
        keyCollected = true;
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (collectedCoins >= totalCoins && key != null)
        {
            key.SetActive(true); // Activate the key when all coins are collected
        }
    }

    public bool Wins()
    {
        return collectedCoins >= totalCoins && keyCollected;
    }
}
