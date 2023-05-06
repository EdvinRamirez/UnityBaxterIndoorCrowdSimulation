using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentPath : MonoBehaviour
{
    public Transform[] allPoints;

    public Vector3[] Cordinates;


    private void Start()
    {
        Cordinates = new Vector3[allPoints.Length];
        for (int i = 0; i <allPoints.Length; i++)
        {
            Cordinates[i] = allPoints[i].position;
        }
    }

    public Vector3 StartPosition()
    {
        return allPoints[0].position;
    }

    public Vector3 LastPosition()
    {
        return allPoints[allPoints.Length - 1].position;
    }

    public Vector3[] getPath()
    {
        return Cordinates;
    }

    void OnDrawGizmosSelected()
    {
        for (int i = 0; i < allPoints.Length - 1; i++)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawLine(allPoints[i].position, allPoints[i + 1].position);
        }
    }
}
