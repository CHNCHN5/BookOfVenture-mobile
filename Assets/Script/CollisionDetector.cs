using UnityEngine;
using UnityEngine.UI;

public class CollisionDetector : MonoBehaviour
{
    public Image imageToActivate;
    private bool isColliding;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = true;
            imageToActivate.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = false;
            imageToActivate.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (!isColliding)
        {
            imageToActivate.gameObject.SetActive(false);
        }
    }
}