using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanvasPresenter
{
    InGameEnum.InGameState State { get; }
    void SetCanvasActive(bool isActive, Parameter parameter);
}
