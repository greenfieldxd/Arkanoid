using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float minX; // Максимальное и минимальное X координат платформы
    public float maxX;
    public bool platformIsActive;

    GameManager gm;//Геймменеджер
    Ball ball;//Мяч


    private void Start()
    {
        platformIsActive = true; //При старте сцены платформа активна
        gm = FindObjectOfType<GameManager>();//Нашли геймменеджер
        ball = FindObjectOfType<Ball>();//Мяч на сцене
    }

    void Update()
    {

        if (gm.autoPlay && ball.IsStarted())
        {
            MoveWithBall();
        }
        else
        {
            PlatformTransform(platformIsActive); // Проверка на движение платформы с мышью
        }
    }

    void PlatformTransform(bool isActive)
    {
        if (isActive)
        {
            Vector3 mousePos = Input.mousePosition;// позиция мыши в координатах камеры
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos); // позиция мыши в координатах мира
                                                                              //Debug.Log("mousePos: " + mousePos + ", mouseWorldPos: " + mouseWorldPos);

            float xPlatform = mouseWorldPos.x;// значение x координат мыши
            float clampedPlatformX = Mathf.Clamp(xPlatform, minX, maxX); // обрезаем координаты платформы по x до нужных нам значений
            float yPlatform = transform.position.y;

            transform.position = new Vector3(clampedPlatformX, yPlatform, 0);
        }
    }


    void MoveWithBall() //Двигаться за мячом
    {    
            transform.position = new Vector3(ball.transform.position.x, transform.position.y, 0); 
    }

    public void ModifyScale(Vector3 scalePlatform)// изменяет SCALE
    {
        transform.localScale = scalePlatform;
    }

}
