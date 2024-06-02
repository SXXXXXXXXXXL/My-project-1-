using UnityEngine;

public class Hazard : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1")) // if player menyentuh hazard
        {
            PlayerRespawn playerRespawn = other.GetComponent<PlayerRespawn>();
            if (playerRespawn != null)
            {
                audioManager.PlaySFX(audioManager.death1);
                playerRespawn.Respawn(); // menjalankan method respawn
            }
        }
        else if (other.CompareTag("Player2")) // if player menyentuh hazard
        {
            PlayerRespawn playerRespawn = other.GetComponent<PlayerRespawn>();
            if (playerRespawn != null)
            {
                audioManager.PlaySFX(audioManager.death2);
                playerRespawn.Respawn(); // menjalankan method respawn
            }
        }
    }
}
