using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private string horizontalControl = "Horizontal"; // Input default movement
    private string jumpControl = "Jump"; // Default input loncat

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw(horizontalControl); // Mendapat inputan utk movement
        Vector2 velocity = rb.velocity;
        velocity.x = horizontal * speed; // Set speed utk movement
        rb.velocity = velocity;

        groundCheck();

        if (isGrounded && Input.GetButtonDown(jumpControl)) // Program utk lompat
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    // Cek apakah karakter nempel tanah
    private void groundCheck()
    {
        RaycastHit2D[] hits = new RaycastHit2D[5];
        int numhits = rb.Cast(Vector2.down, hits, 0.1f);
        isGrounded = numhits > 0;
    }

    // Menetapkan input kontrol kepada masing masing player
    public void SetControls(string horizontal, string jump)
    {
        horizontalControl = horizontal;
        jumpControl = jump;
    }
}