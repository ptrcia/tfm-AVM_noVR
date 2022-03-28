using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class WaitForSeconds : MonoBehaviour
{
    public float seconds;
    public UnityEvent Action;
    
    void Start()
    {
        StartCoroutine(Cuenta());
    }

    IEnumerator Cuenta()
    {
        yield return new WaitForSecondsRealtime(seconds);
        Action.Invoke();
    }
}