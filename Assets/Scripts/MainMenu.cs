using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text bestTextScore;

    // Start is called before the first frame update
    void Start()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");
        bestTextScore.text = "Best score: " + bestScore;
    }

}
