using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPlatformScale : MonoBehaviour
{
    Platform platform;

    void ApplyEffect()// Либо +Scale либо -Scale к Ball
    {
        platform = FindObjectOfType<Platform>();
        int randomScale = Random.Range(0, 2);
        Debug.Log(randomScale);
        if (randomScale == 0)
        {
            platform.ModifyScale(new Vector3(0.5f, 1f, 1f));//-Scale
        }
        else
        {
            platform.ModifyScale(new Vector3(1.5f, 1f, 1f));//+Scale
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
