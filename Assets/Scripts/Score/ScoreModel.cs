using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ScoreModel
{
    private ReactiveProperty<int> _scoreProp;
    public IReadOnlyReactiveProperty<int> ScoreProp => _scoreProp;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public ScoreModel()
    {
        _scoreProp = new ReactiveProperty<int>(0);
    }

    public void AddScore(int addition)
    {
        _scoreProp.Value += addition;
    }

    public void Reset()
    {
        _scoreProp.Value = 0;
    }

    public int GetScore()
    {
        return _scoreProp.Value;
    }
}
