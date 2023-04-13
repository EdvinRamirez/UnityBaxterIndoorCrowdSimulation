using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Text timer;
    private GameManager gameManager;

    private float timeToDestination;  // The amount of time it takes the NavMeshAgent to reach the destination
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

    // Update is called once per frame
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
