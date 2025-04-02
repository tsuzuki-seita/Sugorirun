using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private int addValue;
    [SerializeField] private float countSeconds;
    private Subject<int> _scoreSubject = new Subject<int>();
    
    public IObservable<int> ScoreObservable => _scoreSubject;
    public PlayerEnum.PlayerState inGameState;

    private void Start()
    {
        StartCoroutine(AddCount());
        inGameState = PlayerEnum.PlayerState.Idle;
    }

    private IEnumerator AddCount()
    {
        while (inGameState != PlayerEnum.PlayerState.Dead) // このGameObjectが有効な間実行し続ける
        {
            _scoreSubject.OnNext(addValue);
            yield return new WaitForSeconds(countSeconds);
        }
    }

    public void UpdateText(int scoreValue)
    {
        scoreText.text = "Score：" + scoreValue;
    }
}
