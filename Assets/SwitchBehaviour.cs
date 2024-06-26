using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehaviour : MonoBehaviour
{
    [SerializeField] PlatformBehaviour _platformBehaviour;
    [SerializeField] bool _isPlatformOnSwitch;
    [SerializeField] bool _isPlatformOffSwitch;

    float _switchSizeY;
    Vector3 _switchUpPos;
    Vector3 _switchDownPos;
    float _switchSpeed = 1f;
    float _switchDelay = 0.2f;
    bool _isSwitchPressed = false;
    AudioManager audioManager;
    bool soundPlayed = false;

    // Start is called before the first frame update
    void Awake()
    {
        _switchSizeY = transform.localScale.y;
        _switchUpPos = transform.position;
        _switchDownPos = new Vector3(transform.position.x,
            transform.position.y - (_switchSizeY/8),
            transform.position.z);
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (_isSwitchPressed)
        {
            if (!soundPlayed)
            {
                audioManager.PlaySFX(audioManager.button);
                soundPlayed = true;
            }
            SwitchDown();
        }
        else if (!_isSwitchPressed)
        {
            SwitchUp();
        }
    }

    void SwitchDown()
    {
        if (transform.position != _switchDownPos)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                _switchDownPos,
                _switchSpeed * Time.deltaTime);
        }
    }

    void SwitchUp()
    {
        if (transform.position != _switchUpPos)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                _switchUpPos,
                _switchSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1")|| collision.CompareTag("Player2"))
        {
            _isSwitchPressed = !_isSwitchPressed;

            if (_isPlatformOnSwitch && !_platformBehaviour._isOn)
            {
                _platformBehaviour._isOn = !_platformBehaviour._isOn;
            }

            else if (_isPlatformOffSwitch && _platformBehaviour._isOn)
            {
                _platformBehaviour._isOn = !_platformBehaviour._isOn;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            StartCoroutine(SwitchUpDelay(_switchDelay));
        }
    }

    IEnumerator SwitchUpDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _isSwitchPressed = false;
        soundPlayed = false;
    }
}
