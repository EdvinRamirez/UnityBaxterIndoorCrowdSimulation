using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{

    private ExitsManager exits;
    private GameManager gameManager;

    private NavMeshAgent agent;
    private Transform target;
    private NavMeshPath path;

    private bool isLeaving;

    private float speed;


    void Start()
    {
        GameManager.totalAgents++;
        gameManager = FindObjectOfType<GameManager>();
        exits = ExitsManager._instance;

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

        speed = Random.Range(2.0f, 4.5f);
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }


    void Update()
    {

        if (!isLeaving && gameManager.state == GameManager.State.Emergncy)
        {
            agent.SetDestination(target.position);
            isLeaving = true;
        }

        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= agent.stoppingDistance + 1)
        {
            GameManager.totalAgents--;
            Destroy(this.gameObject);
        }
    }
}