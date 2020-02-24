using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreData 
{
    public int scoreData;

    public ScoreData()
    {
        scoreData = Score.score;
    }
}
