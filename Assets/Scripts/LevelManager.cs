using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    int blocksNumber;
    SceneLoader sceneLoader;
    Platform platform;

    
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
            sceneLoader.LoadNextLevel(); //Load next Scene


        }
    }
}
