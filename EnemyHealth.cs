using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    // declare max and current health, object and it's health bar, score counter
    [SerializeField] int maxHealth = 3;
    [SerializeField] int currentHealth;

    [SerializeField] HealthBar healthBar;
    [SerializeField] GameObject self;

    [SerializeField] ScoreCounter scoreCounter;

    // Start is called before the first frame update
    void Start()
    {
        // the starting current health will always be the max health
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    
    private void OnCollisionEnter2D(Collision2D targetObj)
    {
        // only takes tamage when touching anything tagged bullet
        if(targetObj.gameObject.tag == "Bullet")
        {
            // call take damage method
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        // the current damage and health bar are offset when the method is called
        currentHealth -= 1;
        healthBar.SetHealth(currentHealth);

        // upon reaching 0 health, the monster is destroyed and removed from the sprite list
        if (currentHealth == 0)
        {
            Destroy(self);

            // accesses the score sprite and adds one
            // the logic for high score is covered on the ScoreCounter.cs file
            scoreCounter.AddScore(maxHealth);
        }
    }
}
