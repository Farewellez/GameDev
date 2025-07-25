using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Any type of user input action can be used
    public InputAction moveAction; // Action to handle movement input
    // Player movement speed
    public float speed = 3.0f;

    public int maxhealth = 5; // Maximum health of the player
    public int health { get { return currentHealth; } } // Current health of the player
    int currentHealth; // Variable to store the current health of the player

    Vector2 movement; // Variable to store the movement input
    Rigidbody2D rb; // Reference to the Rigidbody2D component

    public float timeInvincible = 2.0f; // Duration of invincibility after taking damage
    private bool isInvincible;
    float damageCooldown = 2.0f; // Cooldown time for taking damage

    void Start()
    {
        // Initialization code here
        // QualitySettings.vSyncCount = 0; // Disable VSync
        // Application.targetFrameRate = 60; // Set target frame rate to 60 FPS
        moveAction.Enable(); // Enable the movement action input
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to this GameObject
        currentHealth = maxhealth; // Set the current health to maximum health at the start
    }
    // IEnumerator KnockbackRoutine(Transform spikeTransform)
    // {
    //     isKnockedBack = true;

    //     // Hitung arah knockback (dari spike ke player)
    //     Vector2 knockbackDirection = ((Vector2)transform.position - (Vector2)spikeTransform.position).normalized;

    //     // Terapkan gaya knockback instan
    //     // Gunakan ForceMode2D.Impulse untuk dorongan sekali
    //     rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

    //     // Debug.Log($"Knockback Applied! Direction: {knockbackDirection}, Force: {knockbackForce}"); // Untuk debugging

    //     // Tunggu selama durasi knockback
    //     yield return new WaitForSeconds(knockbackDuration); 

    //     isKnockedBack = false;
    // }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     // Check if the player collides with an object tagged "Spike"
    //     if (other.CompareTag("Spike") && !isKnockedBack)
    //     {
    //         isKnockedBack = true; // Set the knockback flag to true
    //         StartCoroutine(KnockbackRoutine(other.transform)); // Start the knockback coroutine
    //     }
    // }
    void Update()
    {
        movement = moveAction.ReadValue<Vector2>(); // Read the movement input from the action
        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime; // Decrease the cooldown timer
            if (damageCooldown <= 0)
            {
                isInvincible = false; // Reset invincibility after cooldown
                Debug.Log("Player is no longer invincible.");
            }
        }
        // Update logic here
        // Vector2 position = transform.position;
        // position.x += horizontalInput * speed * Time.deltaTime; // Move the player left or right
        // position.y += verticalInput * speed * Time.deltaTime; // Move the player up or down
        // transform.position = position; // Apply the new position

        // Vector2 movement = moveAction.ReadValue<Vector2>(); // Read the movement input
        // Vector2 position = (Vector2)transform.position + movement * speed * Time.deltaTime; // Get the current position of the player

        movement = moveAction.ReadValue<UnityEngine.Vector2>(); // Read the movement input from the action
        // Debug.Log($"Movement Input: {movement}"); // Log the movement input for debugging
        // transform.position = position; // Apply the new position
    }
    void FixedUpdate()
    {
        Vector2 position = (Vector2)rb.position + movement * speed * Time.fixedDeltaTime; // Read the movement input
        rb.MovePosition(position); // Move the player using Rigidbody2D
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible) // Check if the player is invincible
            {
                Debug.Log("Player is invincible! Damage ignored.");
                return; // If the player is invincible, ignore damage
            }
            isInvincible = true; // Set invincibility to true
            damageCooldown = timeInvincible; // Reset the damage cooldown
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxhealth); // Ensure health does not exceed max or go below zero
        Debug.Log($"Current Health: {currentHealth}/{maxhealth}"); // Log the current health for debugging
    }
}
