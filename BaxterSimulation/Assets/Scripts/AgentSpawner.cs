using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class which will spawn agents in a line based on the x and y coridnates 
/// </summary>
public class AgentSpawner : MonoBehaviour
{
    //private Transform transform;
    public GameObject Agent;

    /**
     * Maximum amout of agents to spawn
     */
    public int maxAgents;

    /**
     * The amount to move the x cordinate
     */
    public float moveX;

    /**
     * The amount to move the y cordinate
     */
    private float moveY;

    /**
     * The amount to move the z cordinate
     */
    public float moveZ;


    /**
     * The x cordinate for the next agent to spawn at 
     */
    private float x;

    /**
     * The y cordinate for the next agent to spawn at 
     */
    private float y;

    /**
     * The z cordinate for the next agent to spawn at 
     */
    private float z;

    // Start is called before the first frame update
    void Start()
    {
        //Get position of the curent game agent 
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        SpawnAgents();
    }

    /// <summary>
    /// Spawns agents in line based on the x and z values 
    /// </summary>
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
