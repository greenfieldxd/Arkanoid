using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    private void Awake() //Фикс дублирующихся ГЕЙММЕНЕДЖЕРОВ
    {
        //find all musicPlayers
        MusicPlayer[] musicPlayers = FindObjectsOfType<MusicPlayer>();

        //if more than one
        if (musicPlayers.Length > 1)
        {

            //destroy musicPlayer => if more than one
            Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);  
    }

}
