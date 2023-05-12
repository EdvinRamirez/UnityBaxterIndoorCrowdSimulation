using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

/// <summary>
/// Class for control the agents and to guide them to their destination/exit
/// </summary>
public class AIControl : MonoBehaviour
{
    /**
     * Reference of the ExitsManager in the scene
     */
    private ExitsManager exitsManager;
    
    /**
     * Refrence of the GameManager in the scene
     */
    private GameManager gameManager;

    /**
     * Refrence to the NavMeshAgent 
     */
    private NavMeshAgent agent;

    /**
     * A collection of the paths which the agent will take
     */
    private NavMeshPath[] allPaths;

    /**
     * All the target points for which the agent will passed through 
     */
    private Vector3[] allTargets;

    /**
     * Checks if the agent is leaving or not
     */
    private bool isLeaving;
    
    /**
     * The speed of the agent
     */
    private float speed;

    /// <summary>
    /// Start is called before the first frame update
    /// Also starts getting reference from the scence and also setting agent speed
    /// </summary>
    void Start()
    {
        GameManager.totalAgents++;
        gameManager = FindObjectOfType<GameManager>();
        exitsManager = ExitsManager._instance;

        isLeaving = false;

        speed = Random.Range(gameManager.AgentSpeedmin, gameManager.AgentSpeedmax);
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;

        Invoke(nameof(CalculatePath), 2f);
        //CalculatePath();

        StartCoroutine(StartAgentPath());
    }
    
    /// <summary>
    /// Coroutine which will run infintily until the agent has reach it's destination
    /// Will run through the paths in the collection of paths until last one
    /// </summary>
    /// <returns>Doesn't return as agent will be destroyed at the end</returns>
    IEnumerator StartAgentPath()
    {
        int counter = 0;

        while (true)
        {
            if (!isLeaving && gameManager.state == GameManager.State.Evacuation)
            {
                agent.SetPath(allPaths[0]);
                isLeaving = true;
                counter++;
            }
            else if (isLeaving)
            {

                float distance = Vector3.Distance(transform.position, allTargets[counter - 1]);
                if (distance <= agent.stoppingDistance + 1)
                {
                    if (counter >= allTargets.Length)
                    {
                        break;
                    }
                    agent.SetPath(allPaths[counter]);
                    counter++;
                }
            }
            yield return null;
        }

        yield return new WaitForSeconds(3f);

        Destroy(this.gameObject);
    }

    /// <summary>
    /// Calculates the path for which the agent will take and also calculates all paths in advance 
    /// for the agent 
    /// </summary>
    private void CalculatePath()
    {
        Vector3 myPosition = this.transform.position;
        allTargets = exitsManager.GetAgentPath(myPosition);
        allPaths = new NavMeshPath[allTargets.Length];

        NavMeshPath firstPath = new NavMeshPath();

        NavMesh.CalculatePath(myPosition, allTargets[0], NavMesh.AllAreas, firstPath);

        allPaths[0] = firstPath;

        for (int i = 0; i < allPaths.Length - 1; i++)
        {
            NavMeshPath path = new NavMeshPath();

            NavMesh.CalculatePath(allTargets[i], allTargets[i + 1], NavMesh.AllAreas, path);

            allPaths[i + 1] = path;
        }
    }
}
