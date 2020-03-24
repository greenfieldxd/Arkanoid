using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBallSpeed : MonoBehaviour
{
    public float speedKoef;
    Ball ball;

    void ApplyEffect()// Скорость будет рандомно либо увеличиваться, либо уменьшаться
    {
        ball = FindObjectOfType<Ball>();
        int randomKoef = Random.Range(0, 2);
        if(randomKoef == 0)
        {
            ball.ModifySpeed(1.25f);
        }
        else
        {
            ball.ModifySpeed(0.75f);
        }             
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

