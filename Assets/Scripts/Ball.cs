using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Enter!"); //Произошла коллизия
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision Exit!"); //Вышло из коллизии
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Collision Stay!"); //В коллизии
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Trigger Enter"); // Свойство коллайдера (триггер)
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        Debug.Log("Trigger Exit!"); // Свойство коллайдера (триггер)
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        Debug.Log("Trigger Stay!"); // Свойство коллайдера (триггер)
    }

}
