using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreView : MonoBehaviour
{
    Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText = GetComponent<Text>();
        var param = InGameSceneManager.Instance.GetCurrentParameter<ScoreParameter>();

        if (param != null)
        {
            highScoreText.text = "" + param.HighScore;
        }
        else
        {
            highScoreText.text = "0"; // デフォルト値
        }
    }
}
