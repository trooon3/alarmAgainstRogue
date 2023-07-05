using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueInsideHouseChecker : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    private float _changeSpeed = 0.2f;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    
    private IEnumerator OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Rogue rogue))
        {
            while (_alarmSound.volume < _maxVolume)
            {
                _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, _maxVolume, _changeSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }

    private IEnumerator OnTriggerExit(Collider collider)
    {
         if (collider.TryGetComponent(out Rogue rogue))
        {
            while (_alarmSound.volume > _minVolume)
            {
                _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, _minVolume, _changeSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }

}
