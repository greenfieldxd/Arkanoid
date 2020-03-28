using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpExplodeBall : MonoBehaviour
{
    public int ballsNumber = 2;
    public int pickUpScore;

    Ball ball;
    GameManager gm;

    void ApplyEffect()
    {
        ball = FindObjectOfType<Ball>();
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
