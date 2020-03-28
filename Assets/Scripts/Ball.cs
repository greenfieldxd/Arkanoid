using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speedBall;

    bool stickyBall; //Липкость мяча
    bool started;//Старт мяча
    Platform platform;
    Rigidbody2D rb;
    GameManager gm;
    public GameObject ball;//Объект типа Мяч

    Vector3 ballOffset;




    public bool IsStarted()
    {
        return started;
    }
    

    public void ModifySpeed(float modificator)// Изменяет скорость
    {
        rb.velocity = rb.velocity * modificator;
    }

    public void ModifyScale(float modificator)// изменяет SCALE
    {
        transform.localScale = transform.localScale * modificator;
    }
    public void MakeSticky()
    {
        stickyBall = true;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // найти компонет Rigitbody2D на том же гейм обжекте
        started = false; 
    }

    void Start()
    {

        platform = FindObjectOfType<Platform>(); //Найти Platform на сцене
        gm = FindObjectOfType<GameManager>();

        ballOffset = transform.position - platform.transform.position; //вектор между платформой и мячом
    }


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
        //transform.position = new Vector3(platform.transform.position.x, platform.transform.position.y + 0.6f, 0);
        transform.position = platform.transform.position + ballOffset;
        if (Input.GetMouseButtonDown(0))
        {
            //Запуск мяча
            LaunchBall();
        }
    }

    public void LaunchBall()
    {
        started = true;
        Vector2 force = new Vector2(Random.Range(-1f, 1f), 1).normalized;
        rb.AddForce(force * speedBall);
    }

    public void LockBall()//мячик двигается с платформой и убираем ему скорость
    {
        started = false;
        rb.velocity = new Vector2(0, 0); // Vector2.zero
    }

    public void Dublicate()
    {
        Ball newBall = Instantiate(this);
        newBall.LaunchBall();
        gm.extraBalls++;
        
        if (stickyBall)
        {
            newBall.MakeSticky();
        }
    }

    public void ExplodingBall()//МЯч становится взрывным(будем вызывать используя в pickUpExplodeBall)
    {
        ModifyScale(1.25f);
        ModifySpeed(1.25f);

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        TrailRenderer trail = GetComponentInChildren<TrailRenderer>();

        spriteRenderer.color = Color.green;
        trail.time = 0.4f;
        trail.startColor = Color.yellow;
        trail.endColor = Color.green;

    }

    private void OnCollisionEnter2D(Collision2D collision) //Прикрепляет мяч к платформе
    {
        if (collision.gameObject.CompareTag("Platform") && stickyBall == true) //можно collision.gameObject.tag == "name"
        {
            LockBall();
            stickyBall = false;
            ballOffset = transform.position - platform.transform.position; //Обновляем Offset
        }
    }


    private void OnDrawGizmos()
    {
        if (rb != null)
        {
            Gizmos.color = Color.white;

            Gizmos.DrawLine(transform.position, transform.position + (Vector3)rb.velocity);
        }
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
