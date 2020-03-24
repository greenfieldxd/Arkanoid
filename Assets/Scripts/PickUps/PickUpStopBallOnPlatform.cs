using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpStopBallOnPlatform : MonoBehaviour
{
    Ball ball;

    void ApplyEffect()
    {
        ball = FindObjectOfType<Ball>();
        ball.stickyPlatform = true;
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
