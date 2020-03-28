using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpExplodeBall : MonoBehaviour
{
    public int pickUpScore;

    Ball[] balls;
    GameManager gm;
    

    void ApplyEffect()
    {
        balls = FindObjectsOfType<Ball>();

        foreach (Ball ball in balls)
        {
            ball.ModifyScale(1.25f);
            ball.ModifySpeed(1.25f);
            ball.ModifyTrailBall(Color.green, Color.yellow, Color.green, 0.4f);
            ball.MakeBallExplode();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            gm = FindObjectOfType<GameManager>();
            gm.AddScore(pickUpScore);


            ApplyEffect();
            Destroy(gameObject);//Уничтожаем после применения эффекта
        }
    }
}
