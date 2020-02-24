using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;
    Text scoreText;
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    public void ScoreIncrement()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void SaveScore() 
    {
        SaveSystem.SaveScore();
    }
    public void LoadScore() 
    {
        ScoreData data = SaveSystem.LoadScore();
        score = data.scoreData;
        scoreText.text = score.ToString();
    }

}
