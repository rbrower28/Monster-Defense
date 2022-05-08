using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // sets the health and max health for the player
    [SerializeField] int maxHealth = 3;
    [SerializeField] int currentHealth;

    [SerializeField] GameObject self;

    // retrieves the current health bar status
    [SerializeField] HealthBar healthBar;
    [SerializeField] GameOver gameOverText;

    void Start()
    {
        // does this first, sets the health at max and updates the health bar
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnCollisionEnter2D(Collision2D targetObj)
    {
        // only takes damage when touched by anything with the enemy tag
        if(targetObj.gameObject.tag == "Enemy")
        {
            // call take damage method
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        // lowers the current health by 1 and updates the health bar
        currentHealth--;
        healthBar.SetHealth(currentHealth);

        // given that the health reaches 0, the game ends
        if (currentHealth == 0)
        {
            Destroy(self);
            gameOverText.EndGame();
        }
    }
}
