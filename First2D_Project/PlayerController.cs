using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class PlayerController : MonoBehaviour
{
    // Any type of user input action can be used
    public InputAction moveAction; // Action to handle movement input
    // Player movement speed
    public float speed = 3.0f;

    Rigidbody2D rb; // Reference to the Rigidbody2D component
    
    UnityEngine.Vector2 movement; // Variable to store movement input

    private bool isKnockedBack = false; // Flag to check if the player is knocked back
    public float knockbackForce = 5.0f; // Force applied during knockback
    public float knockbackDuration = 0.5f; // Duration of the knockback effect

    void Start()
    {
        // Initialization code here
        // QualitySettings.vSyncCount = 0; // Disable VSync
        // Application.targetFrameRate = 60; // Set target frame rate to 60 FPS
        moveAction.Enable(); // Enable the movement action input
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to this GameObject
    }
    IEnumerator KnockbackRoutine(Transform spikeTransform)
    {
        isKnockedBack = true;

        // Hitung arah knockback (dari spike ke player)
        Vector2 knockbackDirection = ((Vector2)transform.position - (Vector2)spikeTransform.position).normalized;

        // Terapkan gaya knockback instan
        // Gunakan ForceMode2D.Impulse untuk dorongan sekali
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

        // Debug.Log($"Knockback Applied! Direction: {knockbackDirection}, Force: {knockbackForce}"); // Untuk debugging

        // Tunggu selama durasi knockback
        yield return new WaitForSeconds(knockbackDuration); 

        isKnockedBack = false;
        // Opsional: Hentikan kecepatan pemain setelah knockback jika perlu
        // rb.velocity = Vector2.zero; 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collides with an object tagged "Spike"
        if (other.CompareTag("Spike") && !isKnockedBack)
        {
            isKnockedBack = true; // Set the knockback flag to true
            StartCoroutine(KnockbackRoutine(other.transform)); // Start the knockback coroutine
        }
    }

    void Update()
    {
        // Update logic here
        // Vector2 position = transform.position;
        // position.x += horizontalInput * speed * Time.deltaTime; // Move the player left or right
        // position.y += verticalInput * speed * Time.deltaTime; // Move the player up or down
        // transform.position = position; // Apply the new position

        // Vector2 movement = moveAction.ReadValue<Vector2>(); // Read the movement input
        // Vector2 position = (Vector2)transform.position + movement * speed * Time.deltaTime; // Get the current position of the player

        movement = moveAction.ReadValue<UnityEngine.Vector2>(); // Read the movement input from the action
        Debug.Log($"Movement Input: {movement}"); // Log the movement input for debugging
        // transform.position = position; // Apply the new position
    }

    void FixedUpdate()
    {
        if (!isKnockedBack)
        {
            UnityEngine.Vector2 position = (UnityEngine.Vector2)rb.position + movement * speed * Time.deltaTime; // Get the current position of the Rigidbody2D
            rb.MovePosition(position); // Move the Rigidbody2D to the new position based on input and speed
            // rb.velocity = movement * speed; // Apply the movement velocity to the Rigidbody2D
        }
        // else
        // {
        //     rb.velocity = Vector2.zero; // Stop the Rigidbody2D if knocked back
        // }
    }
}
