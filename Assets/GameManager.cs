using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalCoins;
    private int collectedCoins = 0;
    private bool keyCollected = false;

    public GameObject key;

    private void Start()
    {
        if (key != null)
        {
            key.SetActive(false);
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
    }

    public bool Wins()
    {
        return collectedCoins >= totalCoins && keyCollected;
    }

    private void CheckWinCondition()
    {
        if (collectedCoins >= totalCoins && key != null)
        {
            key.SetActive(true);
        }
    }
}
