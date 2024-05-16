using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector2 lastSafePosition; 
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastSafePosition = transform.position; // menandakan last spot
    }

    public void SetSafePosition(Vector2 position)
    {
        lastSafePosition = position; // mengupdate last spot
    }

    public void Respawn()
    {
        // spawn player ke last spot
        transform.position = lastSafePosition;

        // reset velocity dari player
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
