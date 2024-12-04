using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartEarth()
    {
        SceneManager.LoadScene("Earth"); 
    }

    public void StartMars()
    {
        SceneManager.LoadScene("Mars");
    }

    public void ExitGame()
    {
        // Close the game
        Application.Quit();
    }

}
