using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour
{
    public int damage = 20;
    public float lifespan = 3.0f;


    private void Start()
    {
        Destroy(gameObject, lifespan);

    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(transform.GetComponent<Rigidbody>());
        if (other.tag == "player")
        {

            PlayerDamage damageScript = other.GetComponent<PlayerDamage>();
            if (damageScript != null)
            {

                damageScript.TakeDamage(damage);
                Destroy(gameObject);
            }
        }

    }
}
