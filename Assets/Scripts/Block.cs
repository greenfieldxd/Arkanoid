using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Collider2D))]
public class Block : MonoBehaviour
{
    public Sprite[] spriteLevel;

    public int strength; //задаем силу блока (0, 1, 2)
    public int scoreBlock;// очки за блок
    public GameObject[] pickUp;//prefab of pickUp to create when block destroy


    LevelManager levelManager;
    GameManager gm; // Наш GameManager, чтобы использовать его функции



    public void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        gm = FindObjectOfType<GameManager>();
        levelManager.AddBlockCount(); //Добавляем блок в наш LevelManager в переменную blocksNumber
        scoreBlock = strength + 1;  //очки завны силе блока + 1 (например: сила 2, очки за блок 3 , т.к. разбивается с 3 ударов)
        ChangeSprite(spriteLevel.Length - 1); // Берем sprite блока со сцены (целый)
    }

    private void ChangeSprite(int index) //Смена sprite по индексу
    {
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();
        sprite.sprite = spriteLevel[index];
    }

    private void OnCollisionEnter2D(Collision2D collision) //Либо уничтожаем при коллизии, либо уменьшаем силу блока 
    {

        if (strength == 0)
        {
            gm.AddScore(scoreBlock); // вызываем функцию из GameManager
            DestroyBlock();

        }
        else
        {
            strength--;
            ChangeSprite(strength);

        }
    }

    private void DestroyBlock() //Функция уничтожение блока
    {
        Destroy(gameObject);

        levelManager.RemoveBlockCount(); //Удаляем блок в нашем GameManager из переменной blocksNumber

        CreatePickUpWithChance();
    }

    private void CreatePickUpWithChance()//Создаем PickUp на месте разрушенного блока с шансом 1 к 5 и выбираем Рандомный PickUp
    {
        int chance;
        chance = Random.Range(1, 6);// Шанс 1к 5, не включает 6.
        Debug.Log(chance);

        int randomPickUp; //У нас есть пулл из PickUps, будет выпадать рандомный
        randomPickUp = Random.Range(0, pickUp.Length);


        if (pickUp[randomPickUp] != null && chance == 3) //Выбрали любое значение из 5
        {
            Vector3 pickUpPosition = transform.position;
            Instantiate(pickUp[randomPickUp], pickUpPosition, Quaternion.identity);//Создание объекта на месте разрушенного блока

            //GameObject newObject = Instantiate(pickUp);
            //newObject.transform.position = pickUpPosition;
        }
    }
}
