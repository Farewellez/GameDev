using UnityEngine;

public class HealthCollectible2 : MonoBehaviour
{
    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {

    // }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Health Collectible Triggered!"); // Log for debugging
        PlayerController playerController = other.GetComponent<PlayerController>(); // Get the PlayerController component from the collided object
        if (playerController != null && playerController.health < playerController.maxhealth)
        {
            playerController.ChangeHealth(3); // Call the ChangeHealth method to increase player's health
            Destroy(gameObject); // Destroy the collectible after it has been collected
            // Debug.Log("Player's health is less than maximum!"); // Log for debugging
        }
        else
        {
            Debug.Log("PlayerController not found! OR Your health is full!!!"); // Log for debugging
        }
    }
    
    // // Update is called once per frame
    // void Update()
    // {

    // }
}
