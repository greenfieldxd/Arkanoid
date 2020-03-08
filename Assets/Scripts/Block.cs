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



    public void Start()
    {
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
            Destroy(gameObject);
        }
        else
        {
            strength--;
            ChangeSprite(strength);

        }
    }
}
