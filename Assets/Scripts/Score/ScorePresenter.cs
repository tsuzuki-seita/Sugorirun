using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ScorePresenter : MonoBehaviour
{
    private ScoreModel _model;
    private ScoreView _view;

    private void Start()
    {
        _model = new ScoreModel();
        _view = GetComponent<ScoreView>();
        
        // View からの入力を Model に渡す
        _view.ScoreObservable.Subscribe(addition => _model.AddScore(addition));
        
        // Modelの値が更新されたらViewの位置を変更
        _model.ScoreProp.Subscribe(scoreValue => _view.UpdateText(scoreValue));
    }

    public void AddScore(int addition)
    {
        _model.AddScore(addition);
    }

    public int GetScore()
    {
        return _model.GetScore();
    }
}
