using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBridge : MonoBehaviour
{
    public bool _isOn = false;
    Vector3 _platformOffPos;
    Vector3 _platformOnPos;
    float _platformSpeed = 10f;
    public float platformMovement = 0f;
    public AudioSource onSFX;
    public AudioSource offSFX;

    // Start is called before the first frame update
    void Awake()
    {
        _platformOffPos = transform.position;
        _platformOnPos = new Vector3(transform.position.x,
            transform.position.y - platformMovement,
            transform.position.z);
        onSFX.enabled = false;
        offSFX.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isOn)
        {
            platformOn();
        }
        else if (!_isOn)
        {
            platformOff();
        }
    }

    void platformOn()
    {
        if (transform.position != _platformOnPos)
        {
            onSFX.enabled = true;
            transform.position = Vector3.MoveTowards(transform.position,
                _platformOnPos,
                _platformSpeed * Time.deltaTime);
        }
        else
        {
            onSFX.enabled = false;
        }
    }

    void platformOff()
    {
        if (transform.position != _platformOffPos)
        {
            offSFX.enabled = true;
            transform.position = Vector3.MoveTowards(transform.position,
                _platformOffPos,
                _platformSpeed * Time.deltaTime);
        }
        else
        {
            offSFX.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
