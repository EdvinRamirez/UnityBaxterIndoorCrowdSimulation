using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    private new Transform transform;
    public GameObject Agent;

    public int minAgents;
    public int maxAgents;

    public float moveX;
    public float moveY;
    public float moveZ;

    private float x;
    private float y;
    private float z;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();

        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        SpawnAgents();
    }

    private void SpawnAgents()
    {
        Vector3 nextPosition;
        for (int i = 0; i < maxAgents; i++)
        {
            x += moveX;
            y += moveY;
            z += moveZ;
            nextPosition = new Vector3(x, y, z);
            Instantiate(Agent, nextPosition, Quaternion.identity); 
        }
    }
}
