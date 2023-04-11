using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitsManager : MonoBehaviour
{
    public static ExitsManager _instance;

    public Transform mainEntranceGoal;
    public Transform northLobbyEntrance;
    public Transform emergencyExitSouth;
    public Transform emergencyExitNorth;

    // Start is called before the first frame update

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
            Debug.Log("Instance of GameManager Created");
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }
}
