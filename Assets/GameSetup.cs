using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public PlayerController player1;
    public PlayerController player2;

    void Start()
    {
        // Assign controls for Player 1 (W, A, D)
        player1.SetControls("Horizontal1", "Jump1");

        // Assign controls for Player 2 (Arrow Keys)
        player2.SetControls("Horizontal2", "Jump2");
    }
}
