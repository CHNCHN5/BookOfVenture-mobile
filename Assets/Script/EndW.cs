using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Transform respawnPoint; // Set this in the Unity editor to the point where you want the player to respawn

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Relocate the player to the respawn point
            collision.gameObject.transform.position = respawnPoint.position;
        }
    }
}
