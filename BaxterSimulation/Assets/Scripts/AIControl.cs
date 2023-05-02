using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class AIControl : MonoBehaviour
{

    private ExitsManager exitsManager;
    private GameManager gameManager;
    private SubGoal subGoals;

    private NavMeshAgent agent;
    private Transform target;
    private NavMeshPath pathtoSubTarget;
    private NavMeshPath pathToTarget;

    private bool isLeaving;

    private float speed;

    private int totalSubGoal;
    private float subGoalDistances;
    private Transform subGoalPosition;

    private bool isLeavingSeats;

    void Start()
    {
        pathToTarget = new NavMeshPath();
        pathtoSubTarget = new NavMeshPath();

        isLeaving = false;
        isLeavingSeats = false;

        GameManager.totalAgents++;
        gameManager = FindObjectOfType<GameManager>();
        exitsManager = ExitsManager._instance;
        subGoals = SubGoal._instance;

        float closestDistance = 9999999999f;
        for (int i = 0; i < exitsManager.mainExits.Length; i++)
        {
            float distance = Vector3.Distance(exitsManager.mainExits[i].position, transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                target = exitsManager.mainExits[i];
            }

        }

        speed = Random.Range(gameManager.AgentSpeedmin, gameManager.AgentSpeedmax);
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;


        totalSubGoal = subGoals.subGoal.Length;
        subGoalDistances = float.MaxValue;

        for (int i = 0; i < totalSubGoal; i++)
        {
            float distance = Vector3.Distance(subGoals.subGoal[i].position, transform.position);
            if (distance < subGoalDistances)
            {
                subGoalDistances = distance;
                subGoalPosition = subGoals.subGoal[i];
            }
        }

        NavMesh.CalculatePath(transform.position, subGoalPosition.position, NavMesh.AllAreas, pathtoSubTarget);

        StartCoroutine(MyCoroutine());
    }


    IEnumerator MyCoroutine()
    {
        while (true)
        {
            if (!isLeaving && gameManager.state == GameManager.State.Emergncy)
            {
                //agent.SetDestination(subGoalPosition.position);
                agent.SetPath(pathtoSubTarget);
                isLeaving = true;
                isLeavingSeats = true;
                NavMesh.CalculatePath(subGoalPosition.position, target.position, NavMesh.AllAreas, pathToTarget);
            }
            else if (isLeaving)
            {
                if (isLeavingSeats)
                {
                    float distance = Vector3.Distance(subGoalPosition.position, transform.position);
                    if (distance <= agent.stoppingDistance + 1)
                    {
                        isLeavingSeats = false;

                        agent.SetPath(pathToTarget);
                    }
                }
                else
                {
                    float distance = Vector3.Distance(target.position, transform.position);
                    if (distance <= agent.stoppingDistance + 1)
                    {
                        GameManager.totalAgents--;
                        break;
                    }
                }
            }

            Color color;

            if (agent.pathPending)
            {
                color = Color.gray;
            }
            else
            {
                color = Color.green;
            }

            GetComponent<Renderer>().material.color = color;

            yield return null;
        }

        yield return new WaitForSeconds(3f);

        Destroy(this.gameObject);
    }
}