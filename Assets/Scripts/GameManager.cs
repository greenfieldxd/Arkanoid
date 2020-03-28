using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0; //очки
    public int extraBalls = 0;//Доп. мячи
    bool pauseActive = false;//активность паузы
    public Image imagePause;// картинка паузы
    public Text textScore;  //набранные очки
    public Image[] imageLives; //сердечки на сцене
    public int lives;//жизни
    public bool gameResult;//РЕЗУЛЬТАТ ИГРЫ

    public bool autoPlay;//Автоигра, проверка на качество игры
    public float autoPlaySpeed;//скорость автоигры

    SceneLoader sceneLoader;// СценЛодер
    Ball ball;//Мяч 

    private void Awake() //Фикс дублирующихся ГЕЙММЕНЕДЖЕРОВ
    {
        GameManager[] gameManagers = FindObjectsOfType<GameManager>();
        if (gameManagers.Length > 1)
        {
            Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    private void Start()
    {        
        sceneLoader = FindObjectOfType<SceneLoader>(); //Нашли SceneLoader на сцене
       


        imagePause.gameObject.SetActive(false);
        gameResult = true;
        textScore.text = "Score: 0";
        lives = imageLives.Length - 1;

        DontDestroyOnLoad(gameObject);

        if (autoPlay)
        {
            Time.timeScale = autoPlaySpeed;
        }


    }

    private void Update()
    {

        PauseGame(); // проверка на паузу
    }


    public void HeartLoss(int index) //Потеря жисни
    {
        
        imageLives[index].gameObject.SetActive(false);

    }
   

    void PauseGame() //Пауза в игре
    {
        Platform platform = FindObjectOfType<Platform>();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseActive)
            {
                if (autoPlay)//Скорость для автоплея после паузы(чтобы сохранять ее)
                {
                    Time.timeScale = autoPlaySpeed;
                }
                else
                {
                    Time.timeScale = 1;
                    
                }

                //turn off Pause
                imagePause.gameObject.SetActive(false);
                pauseActive = false;
                platform.platformIsActive = true; ; //Включаем движение платформы
            }
            else
            {
                //turn on Pause
                imagePause.gameObject.SetActive(true);
                Time.timeScale = 0;
                pauseActive = true;
                platform.platformIsActive = false;//Выключаем движение платформы
            }
        }
    }

    public void CheckLoseOrNot() //Проверка на проигрыш, вызываемая при касании Ground
    {

        if (lives <= 0)//если проиграл
        {
            ReturnAllLives();
            gameResult = false;
            sceneLoader.LoadEndScene();//загрузка последней сцены

        }
        else
        {
            HeartLoss(lives);
            lives--;
            ball = FindObjectOfType<Ball>();//Нашли мяч на сцене. Ищем тут, потому что мячи разные на каждой сцене
            ball.LockBall();
        }



    }


    public void ReturnAllLives()// Возвращение всех жизней
    {
        lives = imageLives.Length - 1;

        for (int i = 0; i < imageLives.Length; i++)
        {
            imageLives[i].gameObject.SetActive(true);
        }
    }


    public void AddScore(int score) // функция добавляет нашему Score значение, которое мы ему передаем
    {
        this.score += score;
        textScore.text = "Score: " + this.score; // выводит на сцену измененный Score
    }

}
