using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private PlayerMovePresenter _playerMovePresenter;

    [SerializeField]
    private ScorePresenter _scorePresenter;

    private Animator _playerAnimator;

    private Animator _enemyAnimator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _playerMovePresenter.Dead();
            Debug.Log("当たったよ");

            _playerAnimator = GetComponent<Animator>(); 
            _enemyAnimator = collision.gameObject.GetComponent<Animator>();
            _ = SetGameStateWithAnimationAsync();
        }
    }

    private async Task SetGameStateWithAnimationAsync()
    {
        await InGameSceneManager.Instance.SetGameStateWithAnimation(InGameEnum.InGameState.GameOver, new ScoreParameter(_scorePresenter.GetScore()),_playerAnimator,_enemyAnimator);
    }
}
