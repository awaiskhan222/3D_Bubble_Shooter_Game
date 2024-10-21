using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linrebderer_Rotation_Script : MonoBehaviour
{
    public Transform cameraTransform;  // Reference to the camera's transform
    public float rotationSpeed = 5.0f; // Speed at which the object rotates

    void Start()
    {
        if (cameraTransform == null)
        {
            // If no camera is assigned, get the main camera by default
            cameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        // Get the camera's current rotation
        Vector3 cameraEulerAngles = cameraTransform.eulerAngles;

        // Apply rotation on both the X and Y axes
        Quaternion targetRotation = Quaternion.Euler(cameraEulerAngles.x, cameraEulerAngles.y, 0);

        // Smoothly rotate the object to match the camera's X and Y rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
