using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destroy : MonoBehaviour
{
    //[SerializeField] public Transform ObjectSpawn;
    public UnityEvent ActionObjectSpawn;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //si el que se cae tiene la etiqueta player
        {
            Destroy(gameObject);
            ActionObjectSpawn.Invoke();
        }
        //Debug.Log(other);
    }
}
