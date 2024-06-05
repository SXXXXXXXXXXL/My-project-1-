using UnityEngine;
using UnityEngine.UI;

public class CancelButton : MonoBehaviour
{
    public GameObject tutorialPanel; // Drag the tutorial panel (or the image) into this field in the Inspector
    public PlayerController playerController; // Reference to the player controller to enable/disable movement

    void Start()
    {
        // Ensure the panel is hidden at the start
        tutorialPanel.SetActive(false);
    }

    public void OnCancelButtonClick()
    {
        // Toggle the visibility of the tutorial panel
        bool isActive = tutorialPanel.activeSelf;
        tutorialPanel.SetActive(!isActive);

        // Enable/disable player movement
        if (playerController != null)
        {
            playerController.enabled = isActive;
        }
    }
}
