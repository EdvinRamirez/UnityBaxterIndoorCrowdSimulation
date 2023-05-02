using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class AIControlV2 : MonoBehaviour
{

    private ExitsManager exitsManager;
    private GameManager gameManager;

    private NavMeshAgent agent;
    private Transform tempTarget;
    private NavMeshPath tempPath;

    private List<NavMeshPath> pathsList;

    private bool isLeaving;

    private float speed;
    private bool isLeavingSeats;
    

    void Start()
    {
        isLeaving = false;
        isLeavingSeats = false;

        pathsList = new List<NavMeshPath>();
        tempPath = new NavMeshPath();

        GameManager.totalAgents++;
        gameManager = FindObjectOfType<GameManager>();
        exitsManager = ExitsManager._instance;

        float pathdistance = 99999999;

        SetPath(exitsManager.firstPoints, transform);
        SetPath(exitsManager.mainExits, tempTarget);
        

        speed = Random.Range(3.0f, 4.5f);
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;


        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        while (true)
        {
            if (!isLeaving && gameManager.state == GameManager.State.Emergncy)
            {
                agent.SetPath(pathsList.ElementAt<NavMeshPath>(0));
                pathsList.RemoveAt(0);
                isLeaving = true;
            }
            else if (isLeaving)
            {
               
            }


            /*
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
            }*/


            yield return null;
        }

        yield return new WaitForSeconds(3f);

        Destroy(this.gameObject);
    }


    private void SetPath(Transform[] points, Transform transform)
    {
        if (points.Length == 0)
        {
            float closestDistance = 99999999;
            for (int i = 0; i < points.Length; i++)
            {
                float distance = Vector3.Distance(points[i].position, transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    tempTarget = points[i];
                }
            }

            NavMesh.CalculatePath(transform.position, tempTarget.position, NavMesh.AllAreas, tempPath);

            pathsList.Add(tempPath);
        }
    }

}