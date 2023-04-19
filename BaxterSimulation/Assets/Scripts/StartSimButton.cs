using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSimButton : MonoBehaviour
{
    // Build number of scene to start when start button is pressed
    public int gameSimScene;
    
    // Start is called before the first frame update
    public void StartSim()
    {
        SceneManager.LoadScene(gameSimScene);
    }
}
