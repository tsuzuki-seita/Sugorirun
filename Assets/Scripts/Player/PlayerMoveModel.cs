using UnityEngine;
using UniRx;

public class PlayerMoveModel
{
    private const float MinPosition = -400f;
    private const float MaxPosition = 400f;
    private ReactiveProperty<float> _positionX = new ReactiveProperty<float>(0f);
    private ReactiveProperty<PlayerEnum.PlayerState> _state = new ReactiveProperty<PlayerEnum.PlayerState>(PlayerEnum.PlayerState.Idle);

    public IReadOnlyReactiveProperty<float> PositionX => _positionX;
    public IReadOnlyReactiveProperty<PlayerEnum.PlayerState> State => _state;

    public void Move(float delta)
    {
        if (Mathf.Approximately(delta, 0))
        {
            _state.Value = PlayerEnum.PlayerState.Idle;
        }
        else
        {
            _positionX.Value = Mathf.Clamp(_positionX.Value + delta, MinPosition, MaxPosition);
            _state.Value = PlayerEnum.PlayerState.Run;
        }
    }

    public void Dead()
    {
        _state.Value = PlayerEnum.PlayerState.Dead;
    }   
}
