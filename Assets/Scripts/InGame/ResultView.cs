using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultView : MonoBehaviour
{
    Text resultText;

    // Start is called before the first frame update
    void Start()
    {
        resultText = GetComponent<Text>();
        var param = InGameSceneManager.Instance.GetCurrentParameter<ScoreParameter>();

        if (param != null)
        {
            resultText.text = "" + param.Score;
        }
        else
        {
            resultText.text = "0"; // デフォルト値
        }
    }
}
