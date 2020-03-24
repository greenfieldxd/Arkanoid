using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speedBall;
    public bool stickyPlatform = false;

    bool started;//Старт мяча
    Platform platform;
    Rigidbody2D rb;
    public GameObject ball;//Объект типа Мяч


   

    public bool IsStarted()
    {
        return started;
    }

    public void ModifySpeed(float modificator)// Изменяет скорость
    {
        rb.velocity = rb.velocity * modificator;
    }

    public void ModifyScale(Vector3 scaleBall)// изменяет SCALE
    {
        transform.localScale = scaleBall;
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

    private void OnCollisionEnter2D(Collision2D collision) //Прикрепляет мяч к платформе
    { 
        if (collision.gameObject.CompareTag("Platform") && stickyPlatform == true)
        {
            LockBall();
            stickyPlatform = false;
        }   
    }

    public void CreateBall() //Функция создания нового мяча, нужно отладить чтобы работало все хорошо
    {
      //  Vector3 ballPosition = transform.position;
      //  Instantiate(ball, ballPosition, Quaternion.identity);

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
