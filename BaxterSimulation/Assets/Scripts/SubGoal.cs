using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubGoal : MonoBehaviour
{

    public static SubGoal _instance;

    public Transform[] subGoal;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
}
