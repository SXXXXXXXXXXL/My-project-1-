using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBehaviour : MonoBehaviour
{
    public bool _isOn = false;
    Vector3 _platformOffPos;
    Vector3 _platformOnPos;
    float _platformSpeed = 10f;
    float _platformSizeX;

    // Start is called before the first frame update
    void Awake()
    {
        _platformSizeX = transform.localScale.x;
        _platformOffPos = transform.position;
        _platformOnPos = new Vector3(transform.position.x - _platformSizeX,
            transform.position.y,
            transform.position.z);
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
            transform.position = Vector3.MoveTowards(transform.position,
                _platformOnPos,
                _platformSpeed * Time.deltaTime);
        }
    }

    void platformOff()
    {
        if (transform.position != _platformOffPos)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                _platformOffPos,
                _platformSpeed * Time.deltaTime);
        }
    }
}
