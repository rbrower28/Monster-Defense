using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // retrieving the firing point and the bullet prefab for loading
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;

    // place to adjust bullet force - higher number is faster
    [SerializeField] float bulletForce = 20f;

    void Update()
    {
        // watches for a mouse click, which fires the bullet
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // this method instatiates a bullet and sets direction and velocity
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
