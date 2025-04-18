using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour
{
    public Transform cam;

    // Start is called before the first frame update
    void LateUpdate()
    {
        transform.LookAt(cam);
    }

    
}
