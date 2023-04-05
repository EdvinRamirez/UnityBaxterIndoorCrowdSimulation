using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour {

    public GameObject mainEntranceGoal;
    public GameObject NorthLobbyExntrance;

    public GameObject EmergencyExitSouth;
    public GameObject EmergencyExitNorth;

    NavMeshAgent agent;
    Transform target;

    private GameManager gameManager;
    private NavMeshPath path;

    private bool isLeaving;

    void Start() {

        gameManager = FindObjectOfType<GameManager>();

        GameManager.totalAgents++;

        float maindistance = Vector3.Distance(mainEntranceGoal.transform.position, transform.position);
        float seconddistance = Vector3.Distance(NorthLobbyExntrance.transform.position, transform.position);

        if (maindistance < seconddistance)
        {
            target = mainEntranceGoal.transform;
        }
        else
        {
            target = NorthLobbyExntrance.transform;
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