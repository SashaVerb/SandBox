using System;
using UnityEngine;

public interface IPatternMenuView : ISwitchable
{
    event Action<Vector3> OnRotate;

    event Action OnGoBack;
}
