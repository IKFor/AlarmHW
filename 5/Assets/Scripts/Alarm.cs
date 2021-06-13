using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _changeRate;

    private bool _isPlaing = false;
    private float _currVolume = 0;
    private float _targetVolume = 1;

    // private void Start()
    // {
    //     _alarmSound.DOFade(0, 3).SetLoops(-1, LoopType.Yoyo).From();
    // }

    void Update()
    {
        _currVolume = Mathf.MoveTowards(_currVolume, _targetVolume, (1 / _changeRate) * Time.deltaTime);

        _alarmSound.volume = _currVolume;

        if (_currVolume == 1)
            _targetVolume = 0;
        else if (_currVolume == 0)
            _targetVolume = 1;
    }

    public void OnAlarm()
    {
        if (_isPlaing)
        {
            _isPlaing = false;
            _alarmSound.Stop();
        }
        else
        {
            _isPlaing = true;
            _alarmSound.Play();
        }
    }
}
