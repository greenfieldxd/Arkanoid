using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ground : MonoBehaviour
{
    GameManager gm;
    Ball[] balls;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gm = FindObjectOfType<GameManager>();//Нашли ГеймМенеджер
        balls = FindObjectsOfType<Ball>();

        if (balls.Length <= 1 && collision.gameObject.CompareTag("Ball"))
        {
            gm.CheckLoseOrNot();//Проверяем проиграли или нет, функция в GameManager         
        }
        else
        {
            Destroy(this.gameObject);
        }
        

    }
}
    

