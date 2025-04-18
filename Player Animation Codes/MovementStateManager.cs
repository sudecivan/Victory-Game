using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{
    public float moveSpeed = 15.0f;
    public float jumpForce = 5.0f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private Animator animator;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
       
    }

    private void Update()
    {
        // Check if the character is on the ground
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f; // Ensure a small negative velocity to keep the character grounded
        }

        // Get horizontal and vertical inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;

        // Apply movement with speed
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        if (horizontalInput == Input.GetAxis("Horizontal"))
        {

            animator.SetBool("isWalking", true);
            animator.SetFloat("horizontalInput", horizontalInput);
            animator.SetFloat("verticalInput", verticalInput);
           

        }
        else {

            animator.SetBool("isWalking", false);
            
        }
        

        // Jumping
        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2.0f * gravity);
            animator.SetTrigger("Space");
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}


