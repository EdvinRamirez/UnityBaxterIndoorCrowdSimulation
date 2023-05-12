using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class will hold an collection of Transform/Vector3 for the points to act as the path for agents
/// </summary>
public class AgentPath : MonoBehaviour
{
    public Transform[] allPoints;

    private Vector3[] Cordinates;

    /// <summary>
    /// The first Frame and also calcuatles all the Vector3 points for each position
    /// of the path
    /// </summary>
    private void Start()
    {
        Cordinates = new Vector3[allPoints.Length];
        for (int i = 0; i <allPoints.Length; i++)
        {
            Cordinates[i] = allPoints[i].position;
        }
    }

    /// <summary>
    /// Returns the starting position of a path as a Vector3
    /// </summary>
    /// <returns>Returns starting Vector3</returns>
    public Vector3 StartPosition()
    {
        return allPoints[0].position;
    }
    /// <summary>
    /// Returns the last position of a path as a Vector3
    /// </summary>
    /// <returns>Retruns last Vector3</returns>
    public Vector3 LastPosition()
    {
        return allPoints[allPoints.Length - 1].position;
    }
    /// <summary>
    /// Return all the points of a path in a Vector3 array 
    /// </summary>
    /// <returns>return all points</returns>
    public Vector3[] getPath()
    {
        return Cordinates;
    }
    /// <summary>
    /// Draws the point in the editor for visualizations
    /// </summary>
    void OnDrawGizmosSelected()
    {
        for (int i = 0; i < allPoints.Length - 1; i++)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawLine(allPoints[i].position, allPoints[i + 1].position);
        }
    }
}
