using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _speedVolumeChange;

    private AudioSource _alarmAudio;
    private WaitForSeconds _waitTime = new WaitForSeconds(0.1f);
    private Coroutine _corutineVolumeTuning;

    private float _minVolume = 0f;

    private void Start()
    {
        _alarmAudio = GetComponent<AudioSource>();
        _alarmAudio.volume = _minVolume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Swindler>(out Swindler swindler))
        {
            if (_corutineVolumeTuning != null)
            {
                StopCoroutine(_corutineVolumeTuning);
            }
            _corutineVolumeTuning = StartCoroutine(VolumeTuning(1));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Swindler>(out Swindler swindler))
        {
            if(_corutineVolumeTuning != null)
            {
                StopCoroutine(_corutineVolumeTuning);
            }
            _corutineVolumeTuning = StartCoroutine(VolumeTuning(0));
        }
    }

    private IEnumerator VolumeTuning(float target)
    {
        while (true)
        {
            _alarmAudio.volume = Mathf.MoveTowards(_alarmAudio.volume, target, _speedVolumeChange * Time.deltaTime);
            yield return _waitTime;
        }
    }
}
