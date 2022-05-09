using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void StartGame() 
    {
        SceneManager.LoadScene("Level1");
    }
    public void ExitGame() 
    {
        Application.Quit();
    }
    public void MainMenu() 
    { 
        SceneManager.LoadScene("MainUI");
    }

    public void Level2() 
    {
        SceneManager.LoadScene("Level2");
    }
    public void Level3() 
    {
        SceneManager.LoadScene("Level3");
    }
}
