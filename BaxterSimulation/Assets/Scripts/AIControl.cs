using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour {
    /*
    public GameObject mainEntranceGoal;
    public GameObject northLobbyExntrance;

    public GameObject emergencyExitSouth;
    public GameObject emergencyExitNorth;
    */

    ExitsManager exits;

    NavMeshAgent agent;
    Transform target;

    private GameManager gameManager;
    private NavMeshPath path;

    private bool isLeaving;

    void Start() {
        GameManager.totalAgents++;
        gameManager = FindObjectOfType<GameManager>();
        exits = ExitsManager._instance;

        float maindistance              = Vector3.Distance(exits.mainEntranceGoal.position,   transform.position);
        float northLobbydistance        = Vector3.Distance(exits.northLobbyEntrance.position, transform.position);
        float emergencysouthdistance    = Vector3.Distance(exits.emergencyExitNorth.position, transform.position);
        float emergencyNorthdistance    = Vector3.Distance(exits.emergencyExitNorth.position, transform.position);

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

        
        
        agent = GetComponent<NavMeshAgent>();
        //Invoke("setAgentDestination", 10f);

        /*
        exit = false;
        isLeaving = false;
        //agent.SetDestination(target.position);
        //path = new NavMeshPath();
        //agent.CalculatePath(target.position, path);
        
        if(path.status == NavMeshPathStatus.PathComplete)
        {
            agent.SetDestination(target.position);
        }
        */
    }


    void Update() {

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

    void setAgentDestination()
    {
        agent.SetDestination(target.position);
    }
}