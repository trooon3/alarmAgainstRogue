using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmVolumeController : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;

    private float _changeSpeed = 0.2f;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private Coroutine _corutine; 
    
    private IEnumerator ControlAlarmVolume(float targetValue)
    {
        while (_alarmSound.volume != targetValue)
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, targetValue, _changeSpeed * Time.deltaTime);
            yield return null;
        }
    }

    public void StartControlAlarmVolume(bool isRogueEnter)
    {
        if (_corutine != null)
        {
            StopCoroutine(_corutine);
        }

        if (isRogueEnter)
        {
            _corutine = StartCoroutine(ControlAlarmVolume(_maxVolume));
        }
        else
        {
            _corutine = StartCoroutine(ControlAlarmVolume(_minVolume));
        }
    }
}
