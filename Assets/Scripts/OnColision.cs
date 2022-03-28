using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    //private GameObject esfera;
    Collider colisionador;

    void Start()
    {
        colisionador = GetComponent<Collider>();
    }

    void Update()
    {
        if (colisionador.isTrigger == true)
        {
            colisionador.enabled = !colisionador.enabled;

            Debug.Log("Collider.enabled = " + colisionador.enabled);
        }
    }
}