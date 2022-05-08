using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // retrieves the player and sets rigid body
    public Transform player;
    private Rigidbody2D rb;

    // sets the movement speed and vector for future use
    [SerializeField] float moveSpeed = 3f;
    private Vector2 movement;

    void Start()
    {
        // sets the RigidBody2D element to rb for future use
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // finds the direction the enemy needs to go to reach player
        Vector3 direction = player.position - transform.position;

        // calculates the angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // sets the sprite rotation towards player
        rb.rotation = angle + 270f;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        // calls movement every frame
        MoveCharacter(movement);
    }

    void MoveCharacter(Vector2 direction)
    {
        // moves the enemy a little in the direction of the player
        // Time.deltaTime is to assure it will be the same speed regardless of framerate
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

}
