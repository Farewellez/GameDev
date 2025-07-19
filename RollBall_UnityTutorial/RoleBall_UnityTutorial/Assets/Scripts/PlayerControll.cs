using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControll : MonoBehaviour
{
    // membuat variabel dengan tipe data class RigidBody
    private Rigidbody rb;

    // make a 2 varible that contains x and y value
    private float movementX;
    private float movementY;

    public float speed = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // This function is called when a move input is detected.
    void OnMove(InputValue movementValue)
    {
        // to catch the user's input value for movement direction and convert to vector2
        Vector2 movementVector = movementValue.Get<Vector2>();

        // fill the value of variable movementX and movementY with the value of movementVector's variable
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // FixedUpdate is called once per fixed frame-rate frame.
    void FixedUpdate()
    {
        // make an instance from class Vector3
        // we using our crativity to input the value of vector3 z with vector2 y (haha its so cool!)
        Vector3 movement = new Vector3(movementX,0.0f, movementY);

        // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * speed);
    }

    // not needed yet
    // // Update is called once per frame
    // void Update()
    // {

    // }
}
