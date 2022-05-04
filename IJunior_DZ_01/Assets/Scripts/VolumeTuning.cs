using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeTuning : MonoBehaviour
{
    [SerializeField] private float _speedVolumeChange;

    private bool _volumeUp = true;
    private bool _volumeDown = false;
    private float _maxVolume = 1f;
    private float _minVolume = 0.1f;

    private void Start()
    {
        AudioListener.volume = _minVolume;
        StartCoroutine(VolumeTuner());
    }

    private IEnumerator VolumeTuner()
    {
        while (_volumeUp)
        {
            AudioListener.volume = Mathf.MoveTowards(AudioListener.volume, _maxVolume, _speedVolumeChange * Time.deltaTime);
            yield return new WaitForSeconds(0.1f);

            if(AudioListener.volume >= _maxVolume)
            {
                _volumeUp = false;
                _volumeDown = true;
            }
        }
        while (_volumeDown)
        {
            AudioListener.volume = Mathf.MoveTowards(AudioListener.volume, _minVolume, _speedVolumeChange * Time.deltaTime);
            yield return new WaitForSeconds(0.1f);

            if (AudioListener.volume <= _minVolume)
            {
                _volumeDown = false;
                _volumeUp = true;
            }
        }
        StartCoroutine(VolumeTuner());
    }
}
