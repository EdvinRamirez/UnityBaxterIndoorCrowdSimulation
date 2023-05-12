using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to updated the camera position based on the AWSD keys
/// </summary>
public class CameraMovement : MonoBehaviour
{
    /**
     * The speed of the camera
     */
    public float moveSpeed;

    /**
     * Refrence to transform object to track orientation of the camera
     */
    public Transform orientation;

    /**
     * The input from the A and D keys for moving horizontal
     */
    float horizontalInput;

    /**
     * The input from the W and S keys for moving vertical
     */
    float verticalInput;

    /**
     * The next direction to move camera based the horizontal and verital input
     */
    Vector3 moveDirection;


    /// <summary>
    /// Start is called before the first frame update
    /// Locks the curse and also hides it
    /// </summary>
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        myInput();
    }

    private void FixedUpdate()
    {
        moveCamera();
    }

    /// <summary>
    /// Gets the value from the input of the awsd keys
    /// </summary>
    private void myInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    /// <summary>
    /// Moves the camera basd on the input 
    /// </summary>
    private void moveCamera()
    {
        //transform.position += transform.forward * verticalInput * moveSpeed * Time.deltaTime;
        //transform.position += transform.right * horizontalInput * moveSpeed * Time.deltaTime;

        //Mathf.Clamp(transform.position.y, 5f, 10f);

        moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

    }
}
