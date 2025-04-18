using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootingInterval = 0.2f;
    public float projectileSpeed = 10.0f;

    private Transform player;
    private float nextShootTime;
    public AudioSource audioSource;
    public Damage script;
    private bool isShooting = false;
    public Animator animator;
   

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nextShootTime = Time.time + shootingInterval;
        audioSource = GetComponent<AudioSource>();
        int CurrentHealth = script.currentHealth;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        isShooting = animator.GetBool("isShooting");

            if (Time.time >= nextShootTime && script.currentHealth >= 0 && isShooting)
            {
                Shoot();
                nextShootTime = Time.time + shootingInterval;
            }
            
            
        
        
        
    }

    private void Shoot()
    {
        audioSource.Play();
        Vector3 shootDirection = (player.position - firePoint.position).normalized;
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectileRigidbody.velocity = shootDirection * projectileSpeed;
    }

    
    
    
}


