using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class for the UI to updated text
/// </summary>
public class UIControl : MonoBehaviour
{
    /**
     * Refrence to the current camera
     */
    public Text currentCamera;

    /**
     * Refrence to the text of state of the game
     */
    public Text currentState;

    /**
     * String for the text of the current camera
     */
    private string cameraTxt;

    /**
     * String for the text of the current state
     */
    private string stateTxt;

    /// <summary>
    /// Start is called before the first frame update
    /// Also the text for the current camera and state are updated
    /// </summary>
    void Start()
    {
        cameraTxt = "Camera: ";
        stateTxt = "Current State: ";
        currentCamera.text = cameraTxt + "Overview Camera";
        currentState.text = stateTxt + "Normal";
    }

    /// <summary>
    /// Changes the text of the current camera based on the string passed
    /// </summary>
    /// <param name="text">The String for the text to change</param>
    public void ChangeCameraText(string text)
    {
        currentCamera.text = cameraTxt + text;
    }

    /// <summary>
    /// Changes the text of the current state based on the string passed
    /// </summary>
    /// <param name="text">The String for the text to change </param>
    public void ChangeStateText(string text)
    {
        currentState.text = stateTxt + text;
    }
}
