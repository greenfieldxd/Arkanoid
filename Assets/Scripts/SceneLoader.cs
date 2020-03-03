using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public void LoadNextLevel()
    {
        int activeSneneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSneneIndex + 1);
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
