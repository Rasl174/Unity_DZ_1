using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeTuning : MonoBehaviour
{
    private bool _volumeUp = false;
    private bool _volumeDown = true;

    private void Update()
    {
        VolumeDown();
        VolumeUp();
    }

    private void VolumeUp()
    {
        if (_volumeUp == true)
        {
            AudioListener.volume += Time.deltaTime * 0.2f;
        }
        if (AudioListener.volume >= 0.9f)
        {
            _volumeDown = true;
            _volumeUp = false;
        }
    }

    private void VolumeDown()
    {
        if (_volumeDown == true)
        {
            AudioListener.volume -= Time.deltaTime * 0.2f;
        }
        if(AudioListener.volume <= 0.2f)
        {
            _volumeDown = false;
            _volumeUp = true;
        }
    }
}
