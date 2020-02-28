using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;

    public int ScoreIncrement()
    {
        return score++;
    }

    public void SaveScore() 
    {
        SaveSystem.SaveScore();
    }

    public void LoadScore() 
    {
        ScoreData data = SaveSystem.LoadScore();
        score = data.scoreData;
    }
}
