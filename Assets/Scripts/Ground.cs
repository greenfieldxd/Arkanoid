using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ground : MonoBehaviour
{
    SceneLoader sceneLoader;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        sceneLoader.RestartScene();
    }
    
}
