using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ground : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();//Нашли ГеймМенеджер  
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (gm.extraBalls == 0)
            {
                gm.CheckLoseOrNot();//Проверяем проиграли или нет, функция в GameManager         
            }
            else
            {
                gm.extraBalls--;
                Destroy(collision.gameObject);
            }
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
    

