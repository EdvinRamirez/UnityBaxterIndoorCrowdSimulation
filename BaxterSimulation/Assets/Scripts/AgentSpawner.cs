using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    private new Transform transform;
    private static int Max;
    public GameObject Agent;

    private float x;
    private float y;
    private float z;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        Max = 15;

        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        SpawnAgents();
    }

    private void SpawnAgents()
    {
        Vector3 nextPosition;
        for (int i = 0; i < Max; i++)
        {
            x += 1.1f;
            nextPosition = new Vector3(x, y, z);
            Instantiate(Agent, nextPosition, Quaternion.identity); 
        }
    }
}
