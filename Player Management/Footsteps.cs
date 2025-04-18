using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{   public AudioClip[] footstepClips;
    public AudioSource audioSource;
    public CharacterController controller;
    public float footstepTheshold;
    public float footstepRate;
    private float lastfsTime;


    private void FixedUpdate()
    {


        if(controller.velocity.magnitude > footstepTheshold) {


            if(Time.time - lastfsTime > footstepRate) {


                lastfsTime = Time.time;
                audioSource.PlayOneShot(footstepClips[Random.Range(0,footstepClips.Length)]);


            }



        }
        
    }
}
