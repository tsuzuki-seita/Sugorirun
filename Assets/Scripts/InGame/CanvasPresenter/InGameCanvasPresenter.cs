using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCanvasPresenter : MonoBehaviour,ICanvasPresenter
{
    public InGameEnum.InGameState State => InGameEnum.InGameState.InGame;
    private Canvas _canvas;

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
    }

    public void SetCanvasActive(bool isActive, Parameter param = null)
    {
        this.gameObject.SetActive(isActive);
    }
}
