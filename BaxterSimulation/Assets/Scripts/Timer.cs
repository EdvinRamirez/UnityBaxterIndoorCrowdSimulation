using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class to updated the timer and text
/// </summary>
public class Timer : MonoBehaviour
{
    /**
     * Refrence of the text for the timer in scene
     */
    public Text timer;

    /**
     * Refrence to the GameManager currently in the scence
     */
    private GameManager gameManager;

    //Parameters for the timer 
    private float timeToDestination;  
    private string timerText;
    private bool isdone;
    private bool isdone2;


    // Start is called before the first frame update
    void Start()
    {
        timerText = "Time passed: ";
        gameManager = FindObjectOfType<GameManager>();
        isdone = false;
        isdone2 = false;
    }

    /// <summary>
    /// Update is called once per frame
    /// Updated the timer each frame during the simulation 
    /// </summary>
    void Update()
    {
        if (!isdone2)
        {
            timeToDestination += Time.deltaTime;
            timer.text = timerText + timeToDestination.ToString("F2");
        }
        

        if (!isdone && gameManager.state == GameManager.State.EvaComplete)
        {
            timeToDestination = Time.timeSinceLevelLoad;  // Record the time it took to reach the destination
            Debug.Log("Time to destination: " + timeToDestination.ToString("F2") + " seconds");
            isdone = true;
            isdone2 = true;
            timer.text = timerText + timeToDestination.ToString("F2");
        }
    }
}
