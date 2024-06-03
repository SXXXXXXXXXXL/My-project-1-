using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.CompilerServices;

public class PushSound : MonoBehaviour
{
    public AudioSource PushSFX;
    bool soundplayed = true;
    Rigidbody2D rb;
    AudioManager audioManager;
    bool isGrounded = false;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PushSFX.enabled = false;
    }

    void Update()
    {
        groundCheck();

        if (Math.Abs(rb.velocity.x) > 0 && isGrounded)
        {
            PushSFX.enabled = true;
        }
        else if (!isGrounded)
        {
            soundplayed = false;
        }
        else
        {
            PushSFX.enabled = false;
        }
    }

    private void groundCheck()
    {
        RaycastHit2D[] hits = new RaycastHit2D[5];
        int numhits = rb.Cast(Vector2.down, hits, 0.1f);
        isGrounded = numhits > 0;
        if (isGrounded && !soundplayed)
        {
            audioManager.PlaySFX(audioManager.mendarat);
            soundplayed = true;
        }
    }
}
