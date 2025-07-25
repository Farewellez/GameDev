using UnityEngine;

public class DamageZone : MonoBehaviour
{
    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {

    // }

    void OnTriggerStay2D(Collider2D other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>(); // Get the PlayerController component from the collided object
        // Check if the player collides with an object tagged "DamageZone"
        if (playerController != null && playerController.health > 0)
        {
            playerController.ChangeHealth(-1); // Call the ChangeHealth method to decrease player's health
            Debug.Log("Player entered Damage Zone! Health decreased by 1."); // Log for debugging
            Debug.Log($"Current Health: {playerController.health}/{playerController.maxhealth}"); // Log the current health for debugging
        }
        else
        {
            Debug.Log("PlayerController not found OR Player already Die!!!"); // Log for debugging
        }
    }

    // // Update is called once per frame
    // void Update()
    // {

    // }
}
