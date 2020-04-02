using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Collider2D))]
public class Block : MonoBehaviour
{
    public Sprite[] spriteLevel;

    [Header ("Шанс 1 к maxChance")]// не включая max chance
    public int maxChance;//
    [Header ("Block settings")]
    public int strength; //задаем силу блока (0, 1, 2)
    public int scoreBlock;// очки за блок
    public float timeInvokeExplode;//задержка уничтожения блоков
    public float explodeRadius; //радиус взрыва взрывного блока
    public bool isExploding;// взрывной или нет
    
    public GameObject[] pickUp;//prefab of pickUp to create when block destroy
    public AudioClip destroySound;
    public GameObject destroyFX;



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

    public void DestroyBlock() //Функция уничтожение блока
    {
        AudioSource audio = FindObjectOfType<AudioSource>();
        audio.PlayOneShot(destroySound);
        DestroyFX();

        Destroy(gameObject);
        CreatePickUpWithChance();// Создание PickUp если выпал шанс
        Explode();// Взрыв, если он возможен у блока

        levelManager.RemoveBlockCount(); //Удаляем блок в нашем GameManager из переменной blocksNumber

    }

    private void Explode()// Если блок взрывной, то взрываем
    {
        if (isExploding)
        {
            //explode

            //layer Mask to filter physics objects
            LayerMask layerMask = LayerMask.GetMask("Block");

            //find objects in radius
            Collider2D[] objectsInRadius = Physics2D.OverlapCircleAll(transform.position, explodeRadius, layerMask);

            //будем использовать foreach
            //Проходим по каждому объекту
            foreach (Collider2D objectI in objectsInRadius)
            {
                if (objectI.gameObject == gameObject)
                {
                    continue;//next iteration
                }

                Block block = objectI.gameObject.GetComponent<Block>();
                if (block == null)
                {
                    //Debug.Log(objectI.gameObject.name);
                    Destroy(objectI.gameObject);
                }
                else
                {
		            block.Invoke("DestroyBlock", timeInvokeExplode);
                    block.gameObject.SetActive(false);             
                }
            }
        }
    }

    void DestroyFX()
    {
        if (destroyFX != null)
        {
            Vector3 fxPosition = transform.position;

            GameObject newObject = Instantiate(destroyFX, fxPosition, Quaternion.identity);
            Destroy(newObject, 5f);
        }
    }

    private void CreatePickUpWithChance()//Создаем PickUp на месте разрушенного блока с шансом 1 к 5 и выбираем Рандомный PickUp
    {
        int chance;
        chance = Random.Range(1, maxChance);// Шанс 1к 5, не включает 6.
        //Debug.Log(chance); показывает выпадение шанса

        int randomPickUp; //У нас есть пулл из PickUps, будет выпадать рандомный
        randomPickUp = Random.Range(0, pickUp.Length);


        if (pickUp[randomPickUp] != null && chance == 1) //Выбрали любое значение из 5
        {
            Vector3 pickUpPosition = transform.position;
            Instantiate(pickUp[randomPickUp], pickUpPosition, Quaternion.identity);//Создание объекта на месте разрушенного блока

            //GameObject newObject = Instantiate(pickUp);
            //newObject.transform.position = pickUpPosition;
        }
    }



    private void OnDrawGizmos()
    {     
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, explodeRadius);
    }

}
