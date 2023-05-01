using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitsManager : MonoBehaviour
{
    public static ExitsManager _instance;

    /*
    public Transform mainEntranceGoal;
    public Transform northLobbyEntrance;
    public Transform emergencyExitSouth;
    public Transform emergencyExitNorth;
    */

    public Transform[] mainExits;
    public Transform[] firstPoints;
    public Transform[] SecondPoints;

    public List<Tuple<Transform, float>> list;


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
    /*
    private void Start()
    {
        float priority = 1;
       for (int i = 0; i < mainExits.Length; i++)
        {
            list.Add(new Tuple<Transform, float>(mainExits[i], 0.4f));
        }
    }*/
}
