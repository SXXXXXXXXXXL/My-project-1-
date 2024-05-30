using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public PlayerController player1;
    public PlayerController player2;

    void Start()
    {
        // menambahkan input kontrol player1 (W,A,D)
        player1.SetControls("Horizontal1", "Jump1");

        // menambahkan input kontrol Player2 (Arrow Keys)
        player2.SetControls("Horizontal2", "Jump2");
    }
}
