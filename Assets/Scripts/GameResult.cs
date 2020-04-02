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
        int newScore = gm.score;
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);

        if (newScore > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", newScore);
        }

        if(gm.gameResult == true)
        {
            endText.text = "Ты выиграл, твои очки составили: " + newScore;
        }
        else
        {
            endText.text = "Ты проиграл, твои очки составили: " + newScore;
        }
    }

    public void ResetScoreAndLivesAfterGame()//Вызов этой функции по кнопке Back to main menu
    {
        gm.score = 0;
        gm.textScore.text = "Score: 0";
        gm.gameResult = true;
    }

    
}
