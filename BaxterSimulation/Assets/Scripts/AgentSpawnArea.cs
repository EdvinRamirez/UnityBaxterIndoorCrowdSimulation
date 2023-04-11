using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentSpawnArea : MonoBehaviour
{
    public Vector3 center;
    public Vector3 size;
    public int AgentCount;

    public GameObject agent;


    // Start is called before the first frame update
    void Start()
    {
        SpawnAgents();
    }

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

    void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireCube(center, size);

    }
}
