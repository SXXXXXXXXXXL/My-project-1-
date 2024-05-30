using UnityEngine;

public class GameSetup1 : MonoBehaviour
{
    public PlayerController1 player1;
    public PlayerController1 player2;

    void Start()
    {
        // menambahkan input kontrol player1 (W,A,D)
        player1.SetControls("Horizontal1", "Jump1");

        // menambahkan input kontrol Player2 (Arrow Keys)
        player2.SetControls("Horizontal2", "Jump2");
    }
}
