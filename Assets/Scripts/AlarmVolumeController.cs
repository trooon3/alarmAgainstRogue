using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmVolumeController : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;

    private float _changeSpeed = 0.2f;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    private IEnumerator _alarmVolumeUpper()
    {
        while (_alarmSound.volume < _maxVolume)
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, _maxVolume, _changeSpeed * Time.deltaTime);
            yield return null;
        }
    }
    
    private IEnumerator _alarmVolumeDowner()
    {
        while (_alarmSound.volume > _minVolume)
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, _minVolume, _changeSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public void StartAlarmVolumeUpper()
    {
        var volumeUpperInJob = _alarmVolumeUpper();

        if (volumeUpperInJob != null)
        {
            StopCoroutine(volumeUpperInJob);
        }

        StartCoroutine(_alarmVolumeUpper());

    }

    public void StartAlarmVolumeDowner()
    {
        var volumeDownerInJob = _alarmVolumeDowner();

        if (volumeDownerInJob != null)
        {
            StopCoroutine(volumeDownerInJob);
        }

        StartCoroutine(_alarmVolumeDowner());
    }

}
