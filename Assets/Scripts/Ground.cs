using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ground : MonoBehaviour
{
    SceneLoader sceneLoader;
    GameManager gm;
    Ball ball;
    Rigidbody2D rbBall;


    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();//нашли sceneLoader
        ball = FindObjectOfType<Ball>();// нашли мяч на сцене
        gm = FindObjectOfType<GameManager>();//Нашли ГеймМенеджер
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (gm.lives <= 0)//если проиграл
        {
            gm.ReturnAllLives();
            gm.gameResult = false;
            sceneLoader.LoadEndScene();//загрузка последней сцены

        }
        else
        {
            gm.HeartLoss(gm.lives);
            gm.lives--;
            LockBall();
        }
        



    }

    private void LockBall()//мячик двигается с платформой и убираем ему скорость
    {
        ball.started = false;
        rbBall = ball.GetComponent<Rigidbody2D>();
        rbBall.velocity = new Vector2(0, 0);
    }

  

    //        sceneLoader = FindObjectOfType<SceneLoader>();
    //      sceneLoader.RestartScene();
}
    

