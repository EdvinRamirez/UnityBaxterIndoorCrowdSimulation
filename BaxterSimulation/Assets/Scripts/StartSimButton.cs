using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class which will start the simulation for different scenes
/// </summary>
public class StartSimButton : MonoBehaviour
{
    /**
     * Build number of scene to start when start button is pressed
     */
    public int gameSimScene;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    public void StartSim()
    {
        SceneManager.LoadScene(gameSimScene);
    }
}
