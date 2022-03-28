using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectPosition : MonoBehaviour
{
    Vector3 lastPos;
    //Transform transform; // drag the object to monitor here
    public float threshold = 0.0f; // minimum displacement to recognize a 

    public UnityEvent onIncrease, onDecrease;

    void Start()
    {
        lastPos = transform.position;
    }

    void Update()
    {
        Vector3 offset = transform.position - lastPos;
        if (offset.y > threshold)
        {
            lastPos = transform.position; // update lastPos
            Increase();                    // code to execute when X is getting bigger
        }
        else
        if (offset.y < -threshold)
        {
            lastPos = transform.position; // update lastPos
            Decrease();                        // code to execute when X is getting smaller 
        }
    }

    private void Decrease()
    {
        onDecrease.Invoke();
    }

    private void Increase()
    {
        onIncrease.Invoke();
    }
}