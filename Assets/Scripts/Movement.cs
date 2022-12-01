using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // CACHE refrences to components
    Rigidbody rb;
    AudioSource audioSource;

    // PARAMETERS
    [SerializeField] float mainThrust = 100f ;
    [SerializeField] float rotationThrust = 1f ;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem boostParticles;
    [SerializeField] ParticleSystem rightParticles;
    [SerializeField] ParticleSystem  leftParticles;


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

    void ProcessThrust()
    {  
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!boostParticles.isPlaying)
        {
            boostParticles.Play();
        }
    }
    void StopThrusting()
    {
        audioSource.Stop();
        boostParticles.Stop();
    }

    void ProcessRotate(){
        if(Input.GetKey(KeyCode.A))
        {
            RotateRight();
        }
        else if(Input.GetKey(KeyCode.D))
        {
            RotateLeft();

        }
        else
        {
            StopRotating();

        }

    }

    void RotateLeft()
    {
        ApplyRotation(-rotationThrust);
        if (!leftParticles.isPlaying)
        {
            leftParticles.Play();
        }
    }

    void RotateRight()
    {
        ApplyRotation(rotationThrust);
        if (!rightParticles.isPlaying)
        {
            rightParticles.Play();
        }
    }
    void StopRotating()
    {
        rightParticles.Stop();
        leftParticles.Stop();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;  //freeze rotation for doing munauelly
        transform.Rotate( Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = true;  //unfreeze rotation for physic engine


    }
}
