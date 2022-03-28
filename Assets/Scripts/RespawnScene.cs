using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnScene : MonoBehaviour
{
    [SerializeField] private string loadLevel;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //si el que se cae tiene la etiqueta player
        {
            SceneManager.LoadScene(loadLevel);
        }
        //Debug.Log(other);
    }
}