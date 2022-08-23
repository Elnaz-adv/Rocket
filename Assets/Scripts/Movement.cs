using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] float mainThrust = 100f ;
    [SerializeField] float rotationThrust = 1f ;
    void Start()
    {
       rb = GetComponent<Rigidbody>();
       audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotate();
    }

    void ProcessThrust(){
        
        
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            } 
        }
        else
        {
            audioSource.Stop();
        }   
    
    }

    void ProcessRotate(){
        if(Input.GetKey(KeyCode.A))
        {;
         ApplyRotation(rotationThrust);
        }
        else if(Input.GetKey(KeyCode.D))
        {
         ApplyRotation( -rotationThrust);
        
        }

    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;  //freeze rotation for doing munauelly
        transform.Rotate(-Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = true;  //unfreeze rotation for physic engine


    }
}
