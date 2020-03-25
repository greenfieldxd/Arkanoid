using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBallSpeed : MonoBehaviour
{
    public float speedKoef;
    Ball[] balls;

    void ApplyEffect()// Либо +Scale либо -Scale к Ball
    {
        balls = FindObjectsOfType<Ball>();

        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].ModifySpeed(speedKoef);
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

