using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueInsideHouseChecker : MonoBehaviour
{
    [SerializeField] private AlarmVolumeController _volumeController;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Rogue rogue))
        {
            _volumeController.StartAlarmVolumeUpper();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent(out Rogue rogue))
        {
            _volumeController.StartAlarmVolumeDowner();
        }
    }
}
