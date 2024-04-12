using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RotateImage : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float rotationSpeed = 30f; // Adjust the speed of rotation as needed
    private bool isRotating = false;

    void Update()
    {
        if (isRotating)
        {
            RotateCounterClockwise();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isRotating = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isRotating = false;
    }

    void RotateCounterClockwise()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}