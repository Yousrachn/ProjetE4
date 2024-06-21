using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string SceneToLoad; 

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}