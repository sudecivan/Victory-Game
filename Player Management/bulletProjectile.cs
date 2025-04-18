using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletProjectile : MonoBehaviour
{
    public int damageAmount = 20;
    public float lifespan = 3.0f;
    

    private void Start()
    {
        Destroy(gameObject, lifespan);

    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(transform.GetComponent<Rigidbody>());
        if(other.tag == "dusman") {

            Damage damageScript = other.GetComponent<Damage>();
            if (damageScript != null) {

                damageScript.TakeDamage(damageAmount);
                Destroy(gameObject);
            }
        }
           
    }
}
