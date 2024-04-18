using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    // Reference to the object you want to activate upon collision
    public GameObject objectToActivate;

    // This function is called when the GameObject collides with another GameObject
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided GameObject has a specific tag (you can customize this)
        if (collision.gameObject.CompareTag("YourTagHere"))
        {
            // Activate the specified GameObject
            objectToActivate.SetActive(true);
        }
    }
}