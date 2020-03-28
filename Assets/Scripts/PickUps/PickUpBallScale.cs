using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBallScale : MonoBehaviour
{
    Ball[] balls;
    GameManager gm;
    public float koefScale;
    public int pickUpScore;

    void ApplyEffect()// Либо +Scale либо -Scale к Ball
    {
        balls = FindObjectsOfType<Ball>();

        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].ModifyScale(koefScale);
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
