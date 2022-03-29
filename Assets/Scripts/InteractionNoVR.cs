using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionNoVR : MonoBehaviour
{
    //private Text yourText;
    public UnityEvent onEnter, onExit, PulsaE;
    private bool EnteredTrigger;
    //public bool keyPressed;


    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {         

        if (other.gameObject.tag == "Player")
        {
            Update();
            onEnter.Invoke();
            EnteredTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            onExit.Invoke(); 
            EnteredTrigger = false;

        }
    }
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (EnteredTrigger == true)
                {
                    PulsaE.Invoke();
                }
            //keyPressed = true;
        }


    }

}
