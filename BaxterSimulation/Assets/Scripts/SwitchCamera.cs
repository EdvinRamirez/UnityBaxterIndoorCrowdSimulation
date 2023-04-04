using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera OverviewCamera;
    public Camera FreeCamera;

    private FreeCameraControl cameracontroller;

    // Start is called before the first frame update
    void Start()
    {
        cameracontroller = FreeCamera.GetComponentInChildren<FreeCameraControl>();
        OverviewCamera.enabled = true;
        FreeCamera.enabled = false;
        cameracontroller.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            OverviewCamera.enabled = false;
            FreeCamera.enabled = true;
            cameracontroller.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OverviewCamera.enabled = true;
            FreeCamera.enabled = false; 
            cameracontroller.enabled = false;
        }
    }
}
