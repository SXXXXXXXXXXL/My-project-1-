using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    public Image tutorialImage; // Drag the Image component from the Canvas into this field in the Inspector

    void Start()
    {
        tutorialImage.gameObject.SetActive(false); // Ensure the tutorial image is hidden at the start
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            tutorialImage.gameObject.SetActive(true); // Show the tutorial image when player reaches the checkpoint
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HideTutorial(); // Hide the tutorial image when player leaves the checkpoint
        }
    }

    public void HideTutorial()
    {
        tutorialImage.gameObject.SetActive(false);
    }
}
