using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    /*
    private GameObject portal;
    private GameObject ParticleSystem1;
    private GameObject ParticleSystem2;
    */
    public float speed = 12f;
    public float gravity = 0 - 9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    /*void Start()
    {
        portal = GameObject.Find("portal");
        portal.gameObject.SetActive(false);
        ParticleSystem1 = GameObject.Find("ParticleSystem1");
        ParticleSystem1.gameObject.SetActive(false);
        ParticleSystem2 = GameObject.Find("ParticleSystem2");
        ParticleSystem2.gameObject.SetActive(false);
    }*/

    Vector3 velocity;
    bool isGrounded;
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
    /*void OnTriggerEnter(Collider obj)
    {

        if (obj.CompareTag("Bola"))
        {
            Destroy(obj.gameObject);
            portal.gameObject.SetActive(true);
            ParticleSystem1.gameObject.SetActive(true);
            ParticleSystem2.gameObject.SetActive(true);
        }
        else
        {
            if (obj.CompareTag("Arbol") || obj.CompareTag("Casa") || obj.CompareTag("Megalito") || obj.CompareTag("Rocas") || obj.CompareTag("Troncos") || obj.CompareTag("Escaleras") || obj.CompareTag("Suelo"))
            {
                for (int i = 0; i < obj.transform.childCount; i++)
                {
                    obj.transform.GetChild(i).GetComponent<TwistDeformer>().enabled = true;
                }
            }
            obj.GetComponent<TwistDeformer>().enabled = true;
        }
    }*/
}