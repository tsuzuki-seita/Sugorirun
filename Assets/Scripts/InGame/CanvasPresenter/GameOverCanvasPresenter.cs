using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCanvasPresenter : MonoBehaviour,ICanvasPresenter
{
    public InGameEnum.InGameState State => InGameEnum.InGameState.GameOver;
    private Canvas _canvas;

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
    }

    public void SetCanvasActive(bool isActive, Parameter param = null)
    {
        this.gameObject.SetActive(isActive);
        if (isActive && param is ScoreParameter scoreParam)
        {
            Debug.Log("GameOverCanvas received score: " + scoreParam.Score);
        }
    }
}
