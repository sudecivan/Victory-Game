using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity=100f;
    public Transform playerbody;
    private float xRotation;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;



        xRotation += mouseY * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation,-80, 80);

   



        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);


        playerbody.Rotate(Vector3.up * mouseX * Time.deltaTime);
        

    }
}
