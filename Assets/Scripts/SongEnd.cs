using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class SongEnd : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] private string loadLevel;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            SceneManager.LoadScene(loadLevel);
        }
    }
}