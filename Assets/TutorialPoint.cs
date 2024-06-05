using UnityEngine;
using UnityEngine.UI;

public class TutorialPoint : MonoBehaviour
{
    public Image tutorialImage; // Drag the Image component from the Canvas into this field in the Inspector
    private bool tutorialShown = false;

    void Start()
    {
        tutorialImage.gameObject.SetActive(false); // Ensure the tutorial image is hidden at the start
        Debug.Log("TutorialPoint script started.");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D called.");
        if (other.CompareTag("Player") && !tutorialShown)
        {
            Debug.Log("Player entered the tutorial point.");
            tutorialImage.gameObject.SetActive(true); // Show the tutorial image when player reaches the checkpoint
            tutorialShown = true; // Ensure the tutorial is shown only once
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited the tutorial point.");
            HideTutorial(); // Hide the tutorial image when player leaves the checkpoint
        }
    }

    public void HideTutorial()
    {
        tutorialImage.gameObject.SetActive(false);
    }
}
