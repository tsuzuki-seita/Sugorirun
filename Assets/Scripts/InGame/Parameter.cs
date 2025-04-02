using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Parameter
{
}

public class ScoreParameter : Parameter
{
    public int Score { get; }
    public int HighScore { get; private set; }

    public ScoreParameter(int score)
    {
        Score = score;
        HighScore = PlayerPrefs.GetInt("HighScore", 0);

        if (Score > HighScore)
        {
            HighScore = Score;
            PlayerPrefs.SetInt("HighScore", HighScore);
            PlayerPrefs.Save();
        }
    }
}