using UnityEngine;

public class CameraController : MonoBehaviour
{
    // create some variable
    public GameObject player; // variable that reference to player as GameObject
    private Vector3 offset; // to fill the value of camera angle

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Calculate the initial offset between the camera's position and the player's position.
        offset = transform.position - player.transform.position;   
    }

    // LateUpdate is called once per frame after all Update functions have been completed.
    void LateUpdate()
    {
        // Maintain the same offset between the camera and player throughout the game.
        transform.position = player.transform.position + offset;    
    }
}
