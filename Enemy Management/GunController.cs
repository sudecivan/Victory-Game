using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float shootForce = 20f;
    public float fireRate = 0.2f;
    public AudioSource audioSource;
    public GameObject Muzzler;

    private bool canShoot = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Muzzler.SetActive(false);
    }

    private void Update()
    {
        if (canShoot && Input.GetMouseButtonDown(0))
        {
            Shoot();
            StartCoroutine(FireRateCooldown());
            audioSource.Play();
            Muzzler.SetActive(true);
        }
        else {

            Muzzler.SetActive(false);


        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        if (bulletRigidbody != null)
        {
            bulletRigidbody.AddForce(bulletSpawnPoint.forward * shootForce, ForceMode.Impulse);
        }
    }

    private IEnumerator FireRateCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}


