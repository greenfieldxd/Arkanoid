using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speedBall;
    public float explodeRadius;
    public float explodeTime;

    bool stickyBall; //Липкость мяча
    bool explodeBall;//Взрывной мяч
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

    public void ModifyTrailBall(Color colorStartTrail, Color colorEndTrail, float timeTrail)
    {
        TrailRenderer newTrail = GetComponentInChildren<TrailRenderer>();
        
        newTrail.time = timeTrail;
        newTrail.startColor = colorStartTrail;
        newTrail.endColor = colorEndTrail;
    }

    //Делаем мяч липким
    public void MakeSticky() 
    {
        stickyBall = true;
    }

    //Делаем мяч взрывным
    public void MakeBallExplode()
    {
        explodeBall = true;
    }

    //Выключаем взрывной мяч
    public void OffBallExplode()
    {
        explodeBall = false;
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

        //Если мяч взрывной выключаю через заданное время
        //Надо сделать чтобы цвет Trail становился нормальным
        if (explodeBall)
        {
            Invoke("OffBallExplode", explodeTime);
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
        if (explodeBall)
        {
            LayerMask layerMask = LayerMask.GetMask("Block");

            Collider2D[] objectsInRadius = Physics2D.OverlapCircleAll(transform.position, explodeRadius, layerMask);

            foreach (Collider2D objectI in objectsInRadius)
            {
                Block block = objectI.gameObject.GetComponent<Block>();
                Destroy(block.gameObject);
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //Прикрепляет мяч к платформе
    {
        if (collision.gameObject.CompareTag("Block"))
        { 
            ExplodingBall();//если explodeBall == true, то выполняется
        }

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





}
