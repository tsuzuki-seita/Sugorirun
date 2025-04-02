using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplayButton : MonoBehaviour
{
    Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Replay);
    }

    void Replay()
    {
        InGameSceneManager.Instance.SetInGameState(InGameEnum.InGameState.InGame);
    }
}
