using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Collider2D))]
public class Block : MonoBehaviour
{
    public Sprite[] spriteLevel;

    public int strength;



    public void Start()
    {
        ChangeSprite(spriteLevel.Length - 1);
    }

    private void ChangeSprite(int index)
    {
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();
        sprite.sprite = spriteLevel[index];
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
