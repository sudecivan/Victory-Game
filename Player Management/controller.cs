using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust this to set the movement speed
    public CharacterController controller;

    void Update()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput) * moveSpeed * Time.deltaTime;

        // Apply the movement to the game object
        controller.transform.Translate(movement);
    }
}


