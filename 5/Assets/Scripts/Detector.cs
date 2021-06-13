using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Detector : MonoBehaviour
{
    [SerializeField] private UnityEvent _detect;

    private bool _isDetected = false;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

        if (hit.collider.GetComponent<Player>() != _isDetected)
        {
            _isDetected = !_isDetected;
            if (_isDetected)
            {
                _detect?.Invoke();
            }
        }

    }
}