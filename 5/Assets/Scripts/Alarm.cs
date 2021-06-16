using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _changeRate;

    private float _currVolume = 0;
    private float _targetVolume = 1;

    private void Update()
    {
        _currVolume = Mathf.MoveTowards(_currVolume, _targetVolume, (1 / _changeRate) * Time.deltaTime);

        _alarmSound.volume = _currVolume;

        if (_currVolume == 1)
            _targetVolume = 0;
        else if (_currVolume == 0)
            _targetVolume = 1;
    }

    public void TurnOnAlarm()
    {
        _alarmSound.Play();
    }

    public void TurnOffAlarm()
    {
        _alarmSound.Stop();
    }
}