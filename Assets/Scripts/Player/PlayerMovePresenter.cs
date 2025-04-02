using UnityEngine;
using UniRx;

public class PlayerMovePresenter : MonoBehaviour
{
    private PlayerMoveModel _model;
    private PlayerMoveView _view;
    [SerializeField]
    private ScoreView _scoreView;

    private void Start()
    {
        _model = new PlayerMoveModel();
        _view = GetComponent<PlayerMoveView>();
        
        // View からの入力を Model に渡す
        _view.MoveInputObservable.Subscribe(delta => _model.Move(delta));
        
        // Modelの値が更新されたらViewの位置を変更
        _model.PositionX.Subscribe(posX => _view.UpdatePosition(posX));

        // Modelの状態変更をViewのアニメーションに反映
        _model.State.Subscribe(state => 
        {    
            _view.UpdateAnimation(state);
            _scoreView.inGameState = state;
        });
    }

    public void Dead()
    {
        _model.Dead();
    }
}
