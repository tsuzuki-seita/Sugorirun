using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using Cysharp.Threading.Tasks;

public class InGameSceneManager : MonoBehaviour
{
    public static InGameSceneManager Instance { get; private set; }
    private int _score;
    private List<ICanvasPresenter> _presenters = new List<ICanvasPresenter>();
    private ReactiveProperty<InGameEnum.InGameState> _currentState = new ReactiveProperty<InGameEnum.InGameState>(InGameEnum.InGameState.Title);
    private Parameter _currentParam;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            FindAllPresenters();
            _currentState.Pairwise()
                .Subscribe(pair => ChangeScene(pair.Current, _currentParam));
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void FindAllPresenters()
    {
        ICanvasPresenter[] presenters = FindObjectsOfType<MonoBehaviour>().OfType<ICanvasPresenter>().ToArray();
        _presenters = new List<ICanvasPresenter>(presenters);
    }

    public void SetInGameState(InGameEnum.InGameState state, Parameter param = null)
    {
        _currentParam = param;
        _currentState.Value = state;
    }

    public void ChangeScene(InGameEnum.InGameState state, Parameter param = null)
    {
        _currentParam = param;
        SceneManager.LoadScene(state.ToString());
        
        // foreach (var presenter in _presenters)
        // {
        //     presenter.SetCanvasActive(presenter.State == state, param);
        // }
    }

    public T GetCurrentParameter<T>() where T : Parameter
    {
        return _currentParam as T;
    }

    public async UniTask SetGameStateWithAnimation(InGameEnum.InGameState state, Parameter param, Animator playerAnimator, Animator enemyAnimator)
    {
        playerAnimator.Play("Sugorilla_dead");
        enemyAnimator.Play("Explosion");

        await UniTask.WhenAll(
            WaitForAnimationEnd(playerAnimator, "Sugorilla_dead"),
            WaitForAnimationEnd(enemyAnimator, "Explosion")
        );

        _currentParam = param;
        _currentState.Value = state;
    }

    private async UniTask WaitForAnimationEnd(Animator animator, string animationName)
    {
        if (animator == null) return;
    
        // アニメーションが開始するまで待機
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
        {
            await UniTask.Yield(PlayerLoopTiming.Update);
        }
        
        // アニメーションが終了するまで待機
        while (animator.GetCurrentAnimatorStateInfo(0).IsName(animationName) &&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            await UniTask.Yield(PlayerLoopTiming.Update);
        }
        
        // アニメーションが完全に終了するのを保証
        //await UniTask.WaitUntil(() => !animator.GetCurrentAnimatorStateInfo(0).IsName(animationName));
    }
}