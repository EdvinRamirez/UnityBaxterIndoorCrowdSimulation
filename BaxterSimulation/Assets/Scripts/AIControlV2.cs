using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class AIControlV2 : MonoBehaviour
{

    private ExitsManager exits;
    private GameManager gameManager;
    private SubGoal subGoals;

    private NavMeshAgent agent;
    private Transform target;
    private NavMeshPath path;

    private bool isLeaving;

    private float speed;

    private int totalSubGoal;
    private float subGoalDistances;
    private Transform subGoalPosition;

    private bool isLeavingSeats;
    /*

    void Start()
    {
        isLeaving = false;
        isLeavingSeats = false;

        GameManager.totalAgents++;
        gameManager = FindObjectOfType<GameManager>();
        exits = ExitsManager._instance;
        subGoals = SubGoal._instance;

        float maindistance = Vector3.Distance(exits.mainEntranceGoal.position, transform.position);
        float northLobbydistance = Vector3.Distance(exits.northLobbyEntrance.position, transform.position);
        float emergencysouthdistance = Vector3.Distance(exits.emergencyExitNorth.position, transform.position);
        float emergencyNorthdistance = Vector3.Distance(exits.emergencyExitNorth.position, transform.position);

        float[] targetlist = { maindistance, northLobbydistance, emergencysouthdistance, emergencyNorthdistance };

        float targestPosition = Mathf.Min(targetlist);

        for (int i = 0; i < targetlist.Length; i++)
        {
            if (targestPosition == targetlist[0])
            {
                target = exits.mainEntranceGoal;
            }
            else if (targestPosition == targetlist[1])
            {
                target = exits.northLobbyEntrance;
            }
            else if (targestPosition == targetlist[2])
            {
                target = exits.emergencyExitSouth;
            }
            else if (targestPosition == targetlist[3])
            {
                target = exits.emergencyExitNorth;
            }
        }

        speed = Random.Range(3.0f, 4.5f);
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

        //StartCoroutine(MyCoroutine());
    }

    
    void Update()
    {


        if (!isLeaving && gameManager.state == GameManager.State.Emergncy)
        {
            agent.SetDestination(subGoalPosition.position);
            isLeaving = true;
            isLeavingSeats = true;
        }
        else if (isLeaving)
        {
            if (isLeavingSeats)
            {
                float distance = Vector3.Distance(subGoalPosition.position, transform.position);
                if (distance <= agent.stoppingDistance + 1)
                {
                    isLeavingSeats = false;

                    agent.SetDestination(target.position);
                }
            }
            else
            {
                float distance = Vector3.Distance(target.position, transform.position);
                if (distance <= agent.stoppingDistance + 1)
                {
                    GameManager.totalAgents--;
                    Destroy(this.gameObject);
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


    }

    /**
    IEnumerator MyCoroutine()
    {
        while (true)
        {
            if (!isLeaving && gameManager.state == GameManager.State.Emergncy)
            {
                agent.SetDestination(subGoalPosition.position);
                isLeaving = true;
                isLeavingSeats = true;
            }
            else if (isLeaving)
            {
                if (isLeavingSeats)
                {
                    float distance = Vector3.Distance(subGoalPosition.position, transform.position);
                    if (distance <= agent.stoppingDistance + 1)
                    {
                        isLeavingSeats = false;

                        agent.SetDestination(target.position);
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
            }

            yield return null;
        }
    }*/
}