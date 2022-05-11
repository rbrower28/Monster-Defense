using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // retrieves the hit animation
    [SerializeField] GameObject hitEffect;

    // runs on collision with any other object
    void OnCollisionEnter2D(Collision2D collision)
    {
        // creates an instance of the explosion animation at the place of impact
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);

        // removes the bullet and the explosion (after about one full animation)
        Destroy(effect, .49f);
        Destroy(gameObject);
    }
}
