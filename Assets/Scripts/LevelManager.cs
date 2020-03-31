using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    int blocksNumber;
    public float nextLevelDelay = 1;
    SceneLoader sceneLoader;

    
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();

        //Альтернативный подход
        //lock[] allBlocks = FindObjectsOfType<Block>();
        //int blocksNumber = allBlocks.Length;
    }

    public void AddBlockCount()
    {
        blocksNumber++;
    }

    public void RemoveBlockCount()
    {
        blocksNumber--;

        if (blocksNumber <= 0)
        {
            //Time.timeScale = 0.2f; как вариант
            Invoke(nameof(LoadNextLevel), nextLevelDelay);
        }
    }

    private void LoadNextLevel()
    {
        sceneLoader.LoadNextLevel(); //Load next Scene

    }
}
