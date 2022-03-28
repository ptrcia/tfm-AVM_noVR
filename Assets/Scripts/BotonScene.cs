using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BotonScene : MonoBehaviour
{
    [SerializeField] private float theshold = 0.1f;
    [SerializeField] private float deadzone = 0.025f;

    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    public UnityEvent onPressed, onReseased;
    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
        _isPressed = false;
    }

    void Update()
    {
        if (!_isPressed && GetValue() + theshold >= 1)
            Pressed();
        if (_isPressed && GetValue() - theshold <= 0)
            Reseased();
    }
    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;
        if (Math.Abs(value) < deadzone)
            value = 0;
        return Mathf.Clamp(value, -1f, 1f);
    }
    private void Pressed()
    {
        _isPressed = true;
        onPressed.Invoke();
    }
    private void Reseased()
    {
        _isPressed = false;
        onReseased.Invoke();
    }
}
