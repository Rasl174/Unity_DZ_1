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
    private bool _swindlerInHouse;

    private void Start()
    {
        _alarmAudio = GetComponent<AudioSource>();
        _alarmAudio.volume = _minVolume;

        StartCoroutine(VolumeTuning());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Swindler")
        {
            _swindlerInHouse = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Swindler")
        {
            _swindlerInHouse = false;
        }
    }

    private IEnumerator VolumeTuning()
    {
        while (true)
        {
            if(_swindlerInHouse)
            {
                _alarmAudio.volume = Mathf.MoveTowards(_alarmAudio.volume, _maxVolume, _speedVolumeChange * Time.deltaTime);
                yield return _waitTime;
            }
            else
            {
                _alarmAudio.volume = Mathf.MoveTowards(_alarmAudio.volume, _minVolume, _speedVolumeChange * Time.deltaTime);
                yield return _waitTime;
            }
        }
    }
}
