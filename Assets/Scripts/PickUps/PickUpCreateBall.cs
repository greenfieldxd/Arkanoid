using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCreateBall : MonoBehaviour
{
    public int ballsNumber = 2;
    Ball ball;


    void ApplyEffect()
    {
        ball = FindObjectOfType<Ball>();

        for (int i = 0; i < ballsNumber; i++)
        {
            ball.Dublicate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {

            ApplyEffect();
            Destroy(gameObject);//Уничтожаем после применения эффекта
        }
    }
}
