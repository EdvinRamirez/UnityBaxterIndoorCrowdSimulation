using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class which switch between cameras based on user input
/// </summary>
public class SwitchCamera : MonoBehaviour
{
    /**
     * Refrenace for the overview camera in the scence
     */
    public Camera OverviewCamera;

    /**
     * Refrence to the Free moveing camera in the scence
     */
    public Camera FreeCamera;

    /**
     * Refrence to script for control of the free moving camera
     */
    private FreeCameraControl cameracontroller;

    /**
     * Refrenace to the UIControl to change camera text when switching cameras
     */
    private UIControl uicontrol;

    /// <summary>
    /// Start is called before the first frame update
    /// Gets all refrence to each global variable and disables one camera
    /// </summary>
    void Start()
    {
        uicontrol = FindObjectOfType<Canvas>().GetComponent<UIControl>();
        cameracontroller = FreeCamera.GetComponentInChildren<FreeCameraControl>();
        OverviewCamera.enabled = true;
        FreeCamera.enabled = false;
        cameracontroller.enabled = false;
    }

    /// <summary>
    /// Update is called once per frame
    /// Checks for when either button '1' or '2' is pressed to change cameras when in scene
    /// and also updated the text to reflect current camera
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            OverviewCamera.enabled = false;
            FreeCamera.enabled = true;
            cameracontroller.enabled = true;
            uicontrol.ChangeCameraText("Free Camera");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OverviewCamera.enabled = true;
            FreeCamera.enabled = false; 
            cameracontroller.enabled = false;
            uicontrol.ChangeCameraText("Overview Camera");
        }
    }
}
