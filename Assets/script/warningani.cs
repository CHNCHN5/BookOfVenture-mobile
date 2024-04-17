using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warningani : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // Find the main camera in the scene
        mainCamera = Camera.main;

        // Check if there's a main camera in the scene
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found in the scene!");
            return;
        }
    }

    void Update()
    {
        // Face the camera
        FaceTowardsCamera();
    }

    void FaceTowardsCamera()
    {
        // Calculate the direction to the camera
        Vector3 directionToCamera = mainCamera.transform.position - transform.position;

        // Make the object face the camera (only rotate around Y axis)
        Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);
        transform.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
    }
}
