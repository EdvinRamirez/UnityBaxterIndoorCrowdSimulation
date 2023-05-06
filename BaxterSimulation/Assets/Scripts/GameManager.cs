using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameManager _instance;

    public static int MaxAgents = 8000;
    public static int totalAgents = 0;

    public float AgentSpeedmin;
    public float AgentSpeedmax;

    private UIControl uicontrol;
    public enum State
    {
        Normal,
        Emergncy,
        EvaComplete
    }

    public State state;
    
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
    

    // Start is called before the first frame update
    void Start()
    {
        state = State.Normal;

        uicontrol = FindObjectOfType<Canvas>().GetComponent<UIControl>();
        Invoke(nameof(ChangeState), 4f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (totalAgents <= 0)
        {
            //Debug.Log("Quiting the apllication");
            Invoke(nameof(ChangeStateComplete), 2f);
            Application.Quit();
        }
    }

    public void ChangeState()
    {
        state = State.Emergncy;
        uicontrol.ChangeStateText(State.Emergncy.ToString());
    }

    public void ChangeStateComplete()
    {
        state = State.EvaComplete;
        uicontrol.ChangeStateText(State.EvaComplete.ToString());
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
