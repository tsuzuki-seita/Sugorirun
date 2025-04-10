using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameButton : MonoBehaviour
{
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() =>  InGameSceneManager.Instance.SetInGameState(InGameEnum.InGameState.InGame));
    }
}
