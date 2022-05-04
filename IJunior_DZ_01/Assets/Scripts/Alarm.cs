using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] 

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _speedVolumeChange;
    
    private AudioSource _alarmAudio;

    private WaitForSeconds _waitTime = new WaitForSeconds(0.1f);

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
        while (true)
        {
            while(_alarmAudio.volume < _maxVolume)
            {
                _alarmAudio.volume = Mathf.MoveTowards(_alarmAudio.volume, _maxVolume, _speedVolumeChange * Time.deltaTime);
                yield return _waitTime;
            }
            while(_alarmAudio.volume > _minVolume)
            {
                _alarmAudio.volume = Mathf.MoveTowards(_alarmAudio.volume, _minVolume, _speedVolumeChange * Time.deltaTime);
                yield return _waitTime;
            }
        }
    }
}
