using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    public Image tutorialImage; // Drag the Image component from the Canvas into this field in the Inspector
    public Button saveButton;   // Drag the Button component from the Canvas into this field in the Inspector
    private bool tutorialShown = false;
    private bool isTutorialVisible = false;
    private PlayerController playerController; // Reference to the player's controller script

    void Start()
    {
        tutorialImage.gameObject.SetActive(false); // Ensure the tutorial image is hidden at the start
        saveButton.onClick.AddListener(ToggleTutorial); // Add listener to the save button

        // Assuming the player has a tag "Player" and PlayerController script is attached to it
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !tutorialShown)
        {
            tutorialImage.gameObject.SetActive(true); // Show the tutorial image when player reaches the checkpoint
            tutorialShown = true; // Ensure the tutorial is shown only once
            isTutorialVisible = true; // Update visibility status
            if (playerController != null)
            {
                playerController.enabled = false; // Disable player controls
            }
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
        isTutorialVisible = false; // Update visibility status
        if (playerController != null)
        {
            playerController.enabled = true; // Enable player controls
        }
    }

    public void ToggleTutorial()
    {
        if (tutorialShown) // Only toggle the tutorial if it was shown before
        {
            isTutorialVisible = !isTutorialVisible;
            tutorialImage.gameObject.SetActive(isTutorialVisible); // Toggle the visibility
            if (playerController != null)
            {
                playerController.enabled = !isTutorialVisible; // Enable/disable player controls based on the tutorial visibility
            }
        }
    }
}
