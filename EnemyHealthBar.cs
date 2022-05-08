using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    // retrieves the enemy object and it's rigidbody element
    [SerializeField] Transform enemy;
    private Rigidbody2D rb;
    
    // sets movement so it can eventually be modified
    private Vector2 movement;

    void Start()
    {
        // sets the variable rb to the current RigidBody2D
        rb = this.GetComponent<Rigidbody2D>();
    }

    // is called immediately after update on every frame
    private void FixedUpdate()
    {
        // places each enemy's health bar right underneath it
        // this way, it doesn't rotate with the sprite and stays under it
        movement.Set(enemy.position.x, enemy.position.y - 1.5f);
        
        // carries out the movement
        rb.MovePosition(movement);
    }

}
