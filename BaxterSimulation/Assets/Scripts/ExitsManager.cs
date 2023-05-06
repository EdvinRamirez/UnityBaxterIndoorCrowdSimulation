using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitsManager : MonoBehaviour
{
    public static ExitsManager _instance;

    private GameObject[] pathCollection;

    private int size;

    // Start is called before the first frame update

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

        pathCollection = GameObject.FindGameObjectsWithTag("Path");
    }
    
    void Start()
    {
        
        size = pathCollection.Length;
    }

    public GameObject[] getPathCollections()
    {
        return pathCollection;
    }

    public Vector3[] GetAgentPath(Vector3 currentPosition)
    {
        Vector3[] AgentPath;

        int indexRetrun = 0;
        float closestPoint = float.MaxValue;

        for (int i = 0; i < size; i++)
        {
            AgentPath path = pathCollection[i].GetComponent<AgentPath>();
            Vector3 position = path.StartPosition();

            float distance = Vector3.Distance(position, currentPosition);

            if (distance < closestPoint)
            {
                closestPoint = distance;
                indexRetrun = i;
            }
        }
        AgentPath = pathCollection[indexRetrun].GetComponent<AgentPath>().getPath();

        return AgentPath;
    }
}
