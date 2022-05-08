using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // sets movement speed - higher means faster
    [SerializeField] float movementSpeed = 8f;

    // retrieves the RigidBody and camera for use
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Camera cam;

    // declares several vectors to be used
    Vector2 movement;
    Vector2 mousePos;


    void Update()
    {
        // gets keyboard inputs - AWSD
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // gets the mouse location
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // called immediately after update
    private void FixedUpdate()
    {
        // sets the movement to wherever the keys indicate
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);

        // calculates the angle and direction to angle towards the mouse
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

}
