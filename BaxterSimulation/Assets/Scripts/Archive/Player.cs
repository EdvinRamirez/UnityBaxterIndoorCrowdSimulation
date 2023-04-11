using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float baseSpeed;
    public float runningAmplifier;

    public bool lockCursor;

    private CharacterController characterControllor;
    private Animator animator;

    private float airTime;
    private float gravity = -9.8f;

    private PlayerMovementInfo playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterControllor = GetComponent<CharacterController>();

        playerMovement = new PlayerMovementInfo();
        playerMovement.baseSpeed = baseSpeed;
        playerMovement.runningAmplifier = runningAmplifier;

        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        airTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        PerformBlendTreeAnimation();
        CalculateDirectionAndDistance();
        PerformPhysicalMovement();

        RotatePlayerWithCamera();
    }

    private void ProcessInput()
    {
        playerMovement.leftAndRight = Input.GetAxis("Horizontal");
        playerMovement.forwardAndBackward = Input.GetAxis("Vertical");

        playerMovement.movingForwards = playerMovement.forwardAndBackward > 0.0f;
        playerMovement.movingBackwards = playerMovement.forwardAndBackward < 0.0f;

        bool running = (playerMovement.movingForwards && Input.GetKey(KeyCode.LeftShift)
                        || 
                        (!playerMovement.movingBackwards 
                        && 
                        (playerMovement.leftAndRight > 0.0f || playerMovement.leftAndRight < 0.0f
                        )
                        ));
        if(running)
        {
            playerMovement.speed = playerMovement.baseSpeed * playerMovement.runningAmplifier;
        }
        else
        {
            playerMovement.speed = playerMovement.baseSpeed;

            playerMovement.forwardAndBackward = playerMovement.forwardAndBackward / 2;
        }
    }

    private void PerformBlendTreeAnimation()
    {
        float leftAndRight = playerMovement.leftAndRight;

        if(playerMovement.movingBackwards)
        {
            leftAndRight = 0.0f;
        }

        animator.SetFloat("LeftAndRight", leftAndRight);
        animator.SetFloat("ForwardAndBackward", playerMovement.forwardAndBackward);
    }

    private void CalculateDirectionAndDistance()
    {
        Vector3 moveDirectionForward = transform.forward * playerMovement.forwardAndBackward;
        Vector3 moveDirectionSide = transform.right * playerMovement.leftAndRight;

        playerMovement.direction = moveDirectionForward + moveDirectionSide;
        playerMovement.normalizedDirection = playerMovement.direction.normalized;

        playerMovement.distance = playerMovement.normalizedDirection * playerMovement.speed * Time.deltaTime;
        GroundPlayer();
    }

    private void PerformPhysicalMovement()
    {
        characterControllor.Move(playerMovement.distance);
    }

    private void GroundPlayer()
    {
        if(characterControllor.isGrounded)
        {
            airTime = 0.0f;
        }
        else // falling
        {
            airTime += Time.deltaTime;
            Vector3 direction = playerMovement.normalizedDirection;

            direction.y += 0.5f * gravity * airTime;

            playerMovement.normalizedDirection = direction;
            playerMovement.distance = playerMovement.normalizedDirection * airTime;
        }
    }

    public void RotatePlayerWithCamera()
    {
        Vector3 rotation;

        if (Input.GetKey(KeyCode.T))
        {
            return;
        }
        else
        {
            rotation = Camera.main.transform.eulerAngles;
            rotation.x = 0;
            rotation.z = 0;

            transform.eulerAngles = rotation;
        }
    }
}
