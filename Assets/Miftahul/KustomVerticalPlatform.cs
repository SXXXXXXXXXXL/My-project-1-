using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KustomVerticalPlatform : MonoBehaviour
{
    public bool _isOn = false;
    Vector3 _platformOffPos;
    Vector3 _platformOnPos;
    float _platformSpeed = 10f;
    public float pergerakan;

    // Start is called before the first frame update
    void Awake()
    {
        _platformOffPos = transform.position;
        _platformOnPos = new Vector3(transform.position.x,
            transform.position.y - pergerakan,
            transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(_isOn)
        {
            platformOn();
        }
        else if(!_isOn)
        {
            platformOff();
        }
    }

    void platformOn()
    {
        if(transform.position != _platformOnPos)
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
