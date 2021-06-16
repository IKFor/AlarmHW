using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Detector : MonoBehaviour
{
    [SerializeField] private UnityEvent _leftHouse;
    [SerializeField] private UnityEvent _enteredHouse;

    private bool _isInside = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (!_isInside)
            {
                _enteredHouse?.Invoke();
                _isInside = true;
            }
            else
            {
                _leftHouse?.Invoke();
                _isInside = false;
            }
        }
    }
}
