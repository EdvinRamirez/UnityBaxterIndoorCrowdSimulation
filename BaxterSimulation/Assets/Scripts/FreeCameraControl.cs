using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraControl : MonoBehaviour
{
    float rotateX = 0f;
    float rotateY = 0f;

    public float sensitivity;
    public float cameraSpeed;

    public Transform orientation;

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity;

        rotateY += mouseX;
        rotateX -= mouseY;
        rotateX = Mathf.Clamp(rotateX, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotateX, rotateY, 0);

    }
}
