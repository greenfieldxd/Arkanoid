using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ground : MonoBehaviour
{ 
    GameManager gm;

    private void Start()
    { 
        gm = FindObjectOfType<GameManager>();//Нашли ГеймМенеджер
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gm.CheckLoseOrNot();//Проверяем проиграли или нет, функция в GameManager
    }


}
    

