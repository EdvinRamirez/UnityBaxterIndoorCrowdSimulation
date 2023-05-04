using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExistManagerV2 : MonoBehaviour
{
    public static ExistManagerV2 _instance;

    public Transform[] path;
    public Transform[] path1;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
            Debug.Log("Instance of GameManager Created");
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

    }
}
