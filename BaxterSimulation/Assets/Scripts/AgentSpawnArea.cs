using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Class will spawn agents in a given area
/// </summary>
public class AgentSpawnArea : MonoBehaviour
{
    /**
     * Center of the Spawn point
     */
    public Vector3 center;
    
    /**
     * Size of the spawn area
     */
    public Vector3 size;

    /**
     * Total amount of agents to spawn
     */
    public int AgentCount;

    /**
     * Prefab for gameObject to spawn
     */
    public GameObject agent;


    // Start is called before the first frame update
    void Start()
    {
        SpawnAgents();
    }

    /// <summary>
    /// Funtions which spawns all agents with the given area size and also how many agents to spawn
    /// </summary>
    private void SpawnAgents()
    {
        for (int i = 0; i < AgentCount; i++)
        {
            float x = UnityEngine.Random.Range(size.x / 2, -size.x / 2);
            float z = UnityEngine.Random.Range(size.z / 2, -size.z / 2);

            Vector3 pos = center + new Vector3(x, 1, z);

            Instantiate(agent, pos, Quaternion.identity);
        }
    }

    /// <summary>
    /// Draws a cube for visualization in the editor to see the spawn area
    /// </summary>
    void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireCube(center, size);

    }
}
