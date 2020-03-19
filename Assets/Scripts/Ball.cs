using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speedBall;

    bool started;//Старт мяча
    Platform platform;
    Rigidbody2D rb;

   

    public bool IsStarted()
    {
        return started;
    }

    public void ModifySpeed(float modificator)
    {
        rb.velocity = rb.velocity * modificator;
    }


    void Start()
    {
        started = false;
        platform = FindObjectOfType<Platform>(); //Найти Platform на сцене
        rb = GetComponent<Rigidbody2D>(); // найти компонет Rigitbody2D на том же гейм обжекте
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            //ничего не делаем
            //Debug.Log(rb.velocity.magnitude);  //сколько юнитов в секунду пролетает мяч
        }
        else
        {
            LockBallToPlatform();
        }
    }

    private void LockBallToPlatform()
    {
        //двигаться с платформой
        transform.position = new Vector3(platform.transform.position.x, platform.transform.position.y + 0.6f, 0);
        if (Input.GetMouseButtonDown(0))
        {
            //Запуск мяча
            started = true;
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        
        Vector2 force = new Vector2(Random.Range(-1f, 1f), 1).normalized;
        rb.AddForce(force * speedBall);
    }

    public void LockBall()//мячик двигается с платформой и убираем ему скорость
    {
        started = false;
        rb.velocity = new Vector2(0, 0); // Vector2.zero
    }





    //примеры коллизий

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Collision Enter!"); //Произошла коллизия
    //}



    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    Debug.Log("Collision Stay!"); //В коллизии
    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //    Debug.Log("Trigger Enter"); // Свойство коллайдера (триггер)
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{

    //    Debug.Log("Trigger Exit!"); // Свойство коллайдера (триггер)
    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{

    //    Debug.Log("Trigger Stay!"); // Свойство коллайдера (триггер)
    //}

}
