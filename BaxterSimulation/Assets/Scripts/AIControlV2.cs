using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

/*
public class AIControlV2 : MonoBehaviour
{

    private ExitsManager exitsManager;
    private GameManager gameManager;

    private NavMeshAgent agent;

    private NavMeshPath[] allPaths;
    private Vector3[] allTargets;

    private int counterPath;

    private int totalPaths;

    private bool isLeaving;
    private bool isWalking;

    private Transform currenttarget;

    private Transform mainTarget;

    private float speed;


    void Start()
    {
        GameManager.totalAgents++;
        gameManager = FindObjectOfType<GameManager>();
        exitsManager = ExitsManager._instance;

        var collection = GameObject.FindGameObjectsWithTag("Path");

        Debug.Log(collection.Length);
        Debug.Log(collection.GetType());

        isLeaving = false;
        isWalking = false;

        counterPath = 0;
        totalPaths = exitsManager.targetCount;

        allPaths = new NavMeshPath[3];
        allTargets = new Vector3[3];


        //mainTargetExit(exitsManager.mainExits, transform.position);

        SetPath(exitsManager.firstPoints, new Vector3(transform.position.x, transform.position.y, transform.position.z));
        //SetPath(exitsManager.SecondPoints, allTargets[0]);
        SetPath(exitsManager.mainExits, allTargets[0]);

        speed = Random.Range(gameManager.AgentSpeedmin, gameManager.AgentSpeedmax);
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;


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
                isWalking = true;
                counter++;
            }
            else if (isLeaving)
            {

                float distance = Vector3.Distance(transform.position, allTargets[counter - 1]);
                if (distance <= agent.stoppingDistance + 1)
                {
                    if (counter >= totalPaths)
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


    private void SetPath(Transform[] points, Vector3 startPosition)
    {


        if (points.Length > 0)
        {
            float closestDistance = float.MaxValue;
            //float closestDistanceBetween = float.MaxValue;
            for (int i = 0; i < points.Length; i++)
            {
                Vector3 endPosition = points[i].position;
                float distance = Vector3.Distance(startPosition, endPosition);
                //float distanceToMainTarget = Vector3.Distance(endPosition, mainTarget.position);

                //float distancebetweenBoth = distance + distanceToMainTarget;

                //if (distancebetweenBoth < closestDistanceBetween)
                //{
                //closestDistanceBetween = distancebetweenBoth;
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    currenttarget = points[i];
                }
                //}
            }

            NavMeshPath path = new NavMeshPath();
            Debug.Log(NavMesh.CalculatePath(startPosition, currenttarget.position, NavMesh.AllAreas, path));

            allPaths[counterPath] = path;
            allTargets[counterPath] = currenttarget.position;
            counterPath++;
        }
    }

    private void mainTargetExit(Transform[] exits, Vector3 start)
    {
        float closestDistance = float.MaxValue;
        for (int i = 0; i < exits.Length; i++)
        {
            float distance = Vector3.Distance(exits[i].position, start);

            if (distance < closestDistance)
            {
                mainTarget = exits[i];
                closestDistance = distance;
            }
        }
    }
}
*/