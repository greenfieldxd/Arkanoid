using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScore : MonoBehaviour
{
    GameManager gm;

    void ApplyEffect()// Либо +3 либо -3 к Score
    {
        gm = FindObjectOfType<GameManager>();
        int randomScore = Random.Range(0, 2);
        Debug.Log(randomScore);
        if (randomScore == 0)
        {
            gm.ChangeScoreWithPickUp(-20);
        }
        else
        {
            gm.ChangeScoreWithPickUp(50);
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
