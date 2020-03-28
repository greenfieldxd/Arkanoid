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
       
        foreach (Ball ball in balls) { ball.ExplodingBall(); }
        
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
