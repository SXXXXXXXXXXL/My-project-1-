using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PushSound : MonoBehaviour
{
    public AudioSource PushSFX;
    bool soundplayed =false;
    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PushSFX.enabled = false;
    }

    void Update()
    {
        if (Math.Abs(rb.velocity.x) > 0)
        {
            PushSFX.enabled = true;
        }
        else
        {
            PushSFX.enabled = false;
        }
    }

}
