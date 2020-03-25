using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpStopBallOnPlatform : MonoBehaviour
{
    Ball[] balls;

    void ApplyEffect()
    {
        balls = FindObjectsOfType<Ball>();

        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].MakeSticky();
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
