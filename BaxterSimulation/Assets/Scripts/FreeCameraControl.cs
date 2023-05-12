using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for the mouse control of the camera
/// </summary>
public class FreeCameraControl : MonoBehaviour
{
    /**
     * The rotation of the x-axis
     */
    float rotateX = 0f;

    /**
     * The rotation of the y-axis
     */
    float rotateY = 0f;

    /**
     * The sensitivity of the mouse 
     */
    public float sensitivity;

    /**
     * The speed for which camera to move
     */
    public float cameraSpeed;

    /**
     * Refrence to transform object to track orientation of the camera
     */
    public Transform orientation;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        UpdatedCameraLookAt();
    }

    /// <summary>
    /// updated where the camera is looking at based on the mouse movement
    /// </summary>
    private void UpdatedCameraLookAt()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity;

        rotateY += mouseX;
        rotateX -= mouseY;
        rotateX = Mathf.Clamp(rotateX, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotateX, rotateY, 0);
    }
}
