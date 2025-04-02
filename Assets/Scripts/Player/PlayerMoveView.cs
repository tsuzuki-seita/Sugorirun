using UnityEngine;
using UniRx;
using System;


public class PlayerMoveView : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Animator animator;
    private Subject<float> _moveInputSubject = new Subject<float>();
    
    public IObservable<float> MoveInputObservable => _moveInputSubject;

    bool dead = false;

    private void Start()
    {
        // 初期位置を0に設定
        transform.position = new Vector3(0f, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        float input = Input.GetAxis("Horizontal");
        _moveInputSubject.OnNext(input * speed * Time.deltaTime);
    }

    public void UpdatePosition(float posX)
    {
        if(!dead) // このGameObjectが有効な間実行し続ける
        {
            transform.position = new Vector3(posX, transform.position.y, transform.position.z);
        }
    }

    public void UpdateAnimation(PlayerEnum.PlayerState state)
    {
        switch (state)
        {
            case PlayerEnum.PlayerState.Idle:
                animator.Play("Sugorilla_idle");
                break;
            case PlayerEnum.PlayerState.Run:
                animator.Play("Sugorilla_run");
                break;
            case PlayerEnum.PlayerState.Dead:
                dead = true;
                return;
        }
    }
}
