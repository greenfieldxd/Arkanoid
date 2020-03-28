using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPlatformScale : MonoBehaviour
{
    Platform platform;
    GameManager gm;

    public float koefScale;
    public int pickUpScore;

    void ApplyEffect()// Либо +Scale либо -Scale к Ball
    {
        platform = FindObjectOfType<Platform>();
        platform.ModifyScale(koefScale);
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
