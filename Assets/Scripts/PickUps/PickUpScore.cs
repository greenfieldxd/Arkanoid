using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScore : MonoBehaviour
{
    GameManager gm;
    public int pickUpScore;

    void ApplyEffect()// Либо +3 либо -3 к Score
    {
        gm = FindObjectOfType<GameManager>();
        gm.AddScore(pickUpScore);
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
