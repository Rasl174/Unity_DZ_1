using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeTuning : MonoBehaviour
{
    [SerializeField] private float _speedVolumeChange;

    private bool _volumeUp = true;
    private bool _volumeDown = false;
    private float _maxVolume = 0.99f;
    private float _minVolume = 0.2f;

    private void Start()
    {
        AudioListener.volume = _minVolume;
    }

    private void Update()
    {
        VolumeUp();
        VolumeDown();
    }

    private void VolumeUp()
    {
        if (_volumeUp == true)
        {
            AudioListener.volume += Time.deltaTime * _speedVolumeChange;
        }
        if (AudioListener.volume >= _maxVolume)
        {
            _volumeDown = true;
            _volumeUp = false;
        }
    }

    private void VolumeDown()
    {
        if (_volumeDown == true)
        {
            AudioListener.volume -= Time.deltaTime * _speedVolumeChange;
        }
        if(AudioListener.volume <= _minVolume)
        {
            _volumeDown = false;
            _volumeUp = true;
        }
    }
}
