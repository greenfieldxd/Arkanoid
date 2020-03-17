using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameResult : MonoBehaviour
{
    public Text endText;
    GameManager gm;


    
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        if(gm.gameResult == true)
        {
            endText.text = "Ты выиграл, твои очки составили: " + gm.score;
        }
        else
        {
            endText.text = "Ты проиграл, твои очки составили: " + gm.score;
        }
    }

    public void ResetScoreAndLivesAfterGame()//Вызов этой функции по кнопке Back to main menu
    {
        gm.score = 0;
        gm.textScore.text = "Score: 0";
        gm.gameResult = true;
    }

    
}
