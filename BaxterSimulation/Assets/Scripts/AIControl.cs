using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour {

    public GameObject mainEntranceGoal;
    public GameObject secondEntranceGoal;
    NavMeshAgent agent;
    Transform target;


    void Start() {
        float maindistance = Vector3.Distance(mainEntranceGoal.transform.position, transform.position);
        float seconddistance = Vector3.Distance(secondEntranceGoal.transform.position, transform.position);



        if (maindistance < seconddistance)
        {
            target = mainEntranceGoal.transform;
        }
        else
        {
            target = secondEntranceGoal.transform;
        }
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
    }


    void Update() {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= agent.stoppingDistance)
        {
            Destroy(this.gameObject);
        }
    }
}