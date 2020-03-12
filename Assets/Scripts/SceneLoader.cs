using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public void LoadNextLevel()
    {
        int activeSneneIndex = SceneManager.GetActiveScene().buildIndex; // Нашли индекс активной сцены
        SceneManager.LoadScene(activeSneneIndex + 1);
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartScene()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex; // Нашли индекс активной сцены
        SceneManager.LoadScene(activeSceneIndex); //перезагружаю сцену после касания земли
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
