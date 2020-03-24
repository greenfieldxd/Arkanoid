using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCreateBall : MonoBehaviour
{
    Ball ball;
    void ApplyEffect()
    {
        ball = FindObjectOfType<Ball>();
        ball.CreateBall();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {

            ApplyEffect();
            Destroy(gameObject);//Уничтожаем после применения эффекта
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
