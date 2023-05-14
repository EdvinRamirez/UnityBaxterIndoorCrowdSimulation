using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///  Class to keep track of the simulation 
/// and also checks when all agents have left the simulation and updatd the state
/// </summary>
public class GameManager : MonoBehaviour
{
    /**
     * Refrence to the object itself
     */
    private GameManager _instance;

    /**
     * Total amount of agents allowed in the scene
     */
    public static int MaxAgents = 8000;

    /**
     * Current number of agents in the scene
     */
    public static int totalAgents = 0;

    /**
     * Minimum agent speed
     */
    public float AgentSpeedmin;

    /**
     * Maximum agent speed
     */
    public float AgentSpeedmax;

    /**
     * Amount of time to change state from Normal to Evacuation when simulation starts
     */
    public float TimeforChangeState;

    /**
     * Refrence to the uicontrol gameobject in scnee
     */
    private UIControl uicontrol;

    public float TimeCalculatePath;

    public float BufferDistanceAgent;


    /// <summary>
    /// Enum for the states of the simulation
    /// </summary>
    public enum State
    {
        Normal,
        Evacuation,
        EvaComplete
    }

    /**
     * Current state of the simulation 
     */
    public State state;
    
    /// <summary>
    /// Awake which first starts to created an instance of the object itself and delete and duplicates
    /// </summary>
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            Debug.Log("Instance of GameManager Created");
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }


    /// <summary>
    /// Start is called before the first frame update
    /// Sets the current state to Normal and updated ui and called changeState after n seconds
    /// </summary>
    void Start()
    {
        state = State.Normal;

        uicontrol = FindObjectOfType<Canvas>().GetComponent<UIControl>();
        Invoke(nameof(ChangeState), TimeforChangeState);
    }

    /// <summary>
    /// Update is called once per frame
    /// checks the total amount of agents in the simulation and if none change state 
    /// </summary>
    void LateUpdate()
    {
        if (totalAgents <= 0)
        {
            //Debug.Log("Quiting the apllication");
            Invoke(nameof(ChangeStateComplete), 2f);
            //Application.Quit();
        }
    }

    /// <summary>
    /// Changes the current state from Normal to Evacuation 
    /// </summary>
    public void ChangeState()
    {
        state = State.Evacuation;
        uicontrol.ChangeStateText(State.Evacuation.ToString());
    }

    /// <summary>
    /// Changes the current state from Evacuation to EvacuationComplete
    /// </summary>
    public void ChangeStateComplete()
    {
        state = State.EvaComplete;
        uicontrol.ChangeStateText(State.EvaComplete.ToString());
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
