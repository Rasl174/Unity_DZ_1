using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] 

public class VolumeTuner : MonoBehaviour
{
    [SerializeField] private float _speedVolumeChange;
    
    private AudioSource _alarmAudio;

    private WaitForSeconds _waitTime = new WaitForSeconds(0.1f);

    private bool _volumeUp = true;
    private bool _volumeDown = false;
    private float _maxVolume = 1f;
    private float _minVolume = 0.1f;

    private void Start()
    {
        
        _alarmAudio = GetComponent<AudioSource>();
        _alarmAudio.volume = _minVolume;

        StartCoroutine(VolumeTuning());
    }

    private IEnumerator VolumeTuning()
    {
        while (_volumeUp)
        {
            _alarmAudio.volume = Mathf.MoveTowards(_alarmAudio.volume, _maxVolume, _speedVolumeChange * Time.deltaTime);
            yield return _waitTime;

            if(_alarmAudio.volume >= _maxVolume)
            {
                _volumeUp = false;
                _volumeDown = true;
            }
        }
        while (_volumeDown)
        {
            _alarmAudio.volume = Mathf.MoveTowards(_alarmAudio.volume, _minVolume, _speedVolumeChange * Time.deltaTime);
            yield return _waitTime;

            if (_alarmAudio.volume <= _minVolume)
            {
                _volumeDown = false;
                _volumeUp = true;
            }
        }
        StartCoroutine(VolumeTuning());
    }
}
