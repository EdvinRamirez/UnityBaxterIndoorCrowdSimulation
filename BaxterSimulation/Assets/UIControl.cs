using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public Text currentCamera;
    public Text currentState;


    private string cameraTxt;
    private string stateTxt;

    // Start is called before the first frame update
    void Start()
    {
        cameraTxt = "Camera: ";
        stateTxt = "Current State: ";
        currentCamera.text = cameraTxt + "Overview Camera";
        currentState.text = stateTxt + "Normal";
    }

    public void ChangeCameraText(string text)
    {
        currentCamera.text = cameraTxt + text;
    }

    public void ChangeStateText(string text)
    {
        currentState.text = stateTxt + text;
    }
}
