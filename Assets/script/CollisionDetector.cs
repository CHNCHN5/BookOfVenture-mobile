using UnityEngine;
using UnityEngine.UI;

public class CollisionDetector : MonoBehaviour
{
    public Image imageToActivate;
    private bool isColliding;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Replace "YourColliderTag" with the tag of your collider
        {
            isColliding = true;
            imageToActivate.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Replace "YourColliderTag" with the tag of your collider
        {
            isColliding = false;
            imageToActivate.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // If you want to deactivate the image when not colliding even during the frame update
        if (!isColliding)
        {
            imageToActivate.gameObject.SetActive(false);
        }
    }
}