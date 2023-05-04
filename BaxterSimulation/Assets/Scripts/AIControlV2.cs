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

    private NavMeshPath[] allPaths;
    private Vector3[] allTargets;

    private int counterPath;

    private bool isLeaving;
    private bool isWalking;

    private Transform currenttarget;

    private float speed;


    void Start()
    {
        isLeaving = false;
        isWalking = false;

        counterPath = 0;

        allPaths = new NavMeshPath[3];
        allTargets = new Vector3[3];

        GameManager.totalAgents++;
        gameManager = FindObjectOfType<GameManager>();
        exitsManager = ExitsManager._instance;

        ChoosePath();

        SetPath(exitsManager.firstPoints, transform.position);
        SetPath(exitsManager.SecondPoints, allTargets[0]);
        SetPath(exitsManager.mainExits, allTargets[1]);

        speed = Random.Range(3.0f, 4.5f);
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
                    if (counter >= 3)
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


    private void SetPath(Transform[] points, Vector3 start)
    {
        Debug.Log(points.Length);

        if (points.Length > 0)
        {
            float closestDistance = float.MaxValue;
            for (int i = 0; i < points.Length; i++)
            {
                float distance = Vector3.Distance(points[i].position, start);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    currenttarget = points[i];
                }
            }

            NavMeshPath path = new NavMeshPath();

            NavMesh.CalculatePath(start, currenttarget.position, NavMesh.AllAreas, path);
            allPaths[counterPath] = path;
            allTargets[counterPath] = currenttarget.position;
            counterPath++;
        }
    }

    private void ChoosePath()
    {
        
    }
}