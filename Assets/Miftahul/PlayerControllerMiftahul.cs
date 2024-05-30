using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System;

public class PlayerControllerMiftahul : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;

    float horizontal;
    Rigidbody2D rb;
    bool isGrounded = false;
    private string horizontalControl = "Horizontal"; // Input default movement
    private string jumpControl = "Jump"; // Default input loncat
    bool isFacingRight = false;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw(horizontalControl); // Mendapat inputan utk movement

        FlipSprite();

        if (isGrounded && Input.GetButtonDown(jumpControl)) // Program utk lompat
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);

    }

    void FlipSprite()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    // Menetapkan input kontrol kepada masing masing player
    public void SetControls(string horizontal, string jump)
    {
        horizontalControl = horizontal;
        jumpControl = jump;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);

    }
}
