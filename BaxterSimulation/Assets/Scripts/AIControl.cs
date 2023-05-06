using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class AIControl : MonoBehaviour
{
    private ExitsManager exitsManager;
    private GameManager gameManager;

    private NavMeshAgent agent;

    private NavMeshPath[] allPaths;
    private Vector3[] allTargets;

    private bool isLeaving;

    private float speed;



    void Start()
    {
        GameManager.totalAgents++;
        gameManager = FindObjectOfType<GameManager>();
        exitsManager = ExitsManager._instance;

        isLeaving = false;

        speed = Random.Range(gameManager.AgentSpeedmin, gameManager.AgentSpeedmax);
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;

        Invoke(nameof(CalculatePath), 1f);
        //CalculatePath();

        StartCoroutine(MyCoroutine());
    }
    
    IEnumerator MyCoroutine()
    {
        int counter = 0;

        while (true)
        {
            if (!isLeaving && gameManager.state == GameManager.State.Emergncy)
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
