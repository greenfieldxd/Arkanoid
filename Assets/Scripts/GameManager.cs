using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    bool pauseActive = false;
    public Text textScore;

    private void Awake()
    {
        GameManager[] gameManagers = FindObjectsOfType<GameManager>();
        if (gameManagers.Length > 1)
        {
            Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        textScore.text = "Score: 0";

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseActive)
            {
                //turn off Pause
                Time.timeScale = 1;
                pauseActive = false;
            }
            else
            {
                //turn on Pause
                Time.timeScale = 0;
                pauseActive = true; //надо сделать чтобы платформа тоже не двигалась
            }
        }
    }




    public void AddScore(int score) // функция добавляет нашему Score значение, которое мы ему передаем
    {
        this.score += score;
        textScore.text = "Score: " + this.score; // выводит на сцену измененный Score
    }
}
