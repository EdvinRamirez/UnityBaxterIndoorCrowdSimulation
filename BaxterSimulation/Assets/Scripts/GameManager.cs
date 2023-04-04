using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameManager _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
            Debug.Log("Instance of NetworkManager Created");
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    public static int MaxAgents = 8000;
    public static int totalAgents = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        totalAgents = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (totalAgents <= 0)
        {
            Application.Quit();
        }
    }
}
