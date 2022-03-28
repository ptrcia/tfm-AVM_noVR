using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Hand : MonoBehaviour
{
    Animator animator;
    private float triggerTarget;
    private float gripTarget;
    private float triggerCurrent;
    private float gripCurrent;
    private string animatorGripParam = "Grip";
    private string animatorTriggerpParam = "Trigger";
    public float speed;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        AnimateHand();
    }
    internal void SetGrip(float v)
    {
        gripTarget = v;    
    }
    internal void SetTrigger(float v)
    {
        triggerTarget = v;
    }
    void AnimateHand()
    {
        if(gripCurrent != gripTarget)
        {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorGripParam, gripCurrent);
        }

        if (triggerCurrent != triggerTarget)
        {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorTriggerpParam, triggerCurrent);
        }
    }
}
