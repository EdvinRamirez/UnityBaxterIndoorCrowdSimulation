using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        
    }

    // Update is called once per frame
    void Update()
    {
        myInput();
    }

    private void FixedUpdate()
    {
        moveCamera();
    }

    private void myInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void moveCamera()
    {
        //transform.position += transform.forward * verticalInput * moveSpeed * Time.deltaTime;
        //transform.position += transform.right * horizontalInput * moveSpeed * Time.deltaTime;

        //Mathf.Clamp(transform.position.y, 5f, 10f);

        moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

    }
}
