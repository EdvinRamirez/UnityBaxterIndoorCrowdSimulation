using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to keep track of the paths for the agents to use 
/// </summary>
public class ExitsManager : MonoBehaviour
{
    /**
     * Refrence to the object itself
     */
    public static ExitsManager _instance;

    /**
     * Reference to every AgentPath in the scence
     */
    private Dictionary<int, GameObject[]> PathCollections2;


    /// <summary>
    /// Awake which first starts to created an instance of the object itself and delete and duplicates
    /// Also gets the reference of all the paths avaiable in the scence 
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

        PathCollections2 = new Dictionary<int, GameObject[]>();

        PathCollections2.Add(1, GameObject.FindGameObjectsWithTag("PathFirstFloor"));
        PathCollections2.Add(2, GameObject.FindGameObjectsWithTag("PathSecondFloor"));
        PathCollections2.Add(3, GameObject.FindGameObjectsWithTag("PathThirdFloor"));
        PathCollections2.Add(4, GameObject.FindGameObjectsWithTag("PathFourthFloor"));


        
    }
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        Invoke(nameof(PrintEverything), 2);
    }

    private void PrintEverything()
    {
        Debug.Log(PathCollections2[1].Length);
        Debug.Log(PathCollections2[2].Length);
        Debug.Log(PathCollections2[3].Length);
        Debug.Log(PathCollections2[4].Length);
    }

    /// <summary>
    /// Returns the array with all the reference of the paths avaiable in the scence
    /// </summary>
    /// <returns>Array of gameobject of type AgentPath</returns>
    public GameObject[] getPathCollections()
    {
        //return pathCollection;
        return null;
    }

    /// <summary>
    /// Calculates the the ideal path for the given agent's position based on the first point in the path 
    /// and chooses the closet path 
    /// </summary>
    /// <param name="currentPosition">The current position of the agent</param>
    /// <returns>Returns the ideal path for the agent</returns>
    public Vector3[] GetAgentPath(Vector3 currentPosition, int FloorLevel)
    {
        
        Vector3[] AgentPath;

        GameObject[] temp = PathCollections2[FloorLevel];
        
        int indexRetrun = 0;
        float closestPoint = float.MaxValue;
        
        for (int i = 0; i < temp.Length; i++)
        {
            AgentPath path = temp[i].GetComponent<AgentPath>();
            Vector3 position = path.StartPosition();

            float distance = Vector3.Distance(position, currentPosition);

            if (distance < closestPoint)
            {
                closestPoint = distance;
                indexRetrun = i;
            }
        }
        AgentPath = temp[indexRetrun].GetComponent<AgentPath>().getPath();

        return AgentPath;
        
    }
}
