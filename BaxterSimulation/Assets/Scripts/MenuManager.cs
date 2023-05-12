using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// class for when the application should quit
/// </summary>
public class MenuManager : MonoBehaviour
{
    /// <summary>
    /// Funtion for quiting the application 
    /// </summary>
    public void QuitGame () {
        Application.Quit();
    }
}
