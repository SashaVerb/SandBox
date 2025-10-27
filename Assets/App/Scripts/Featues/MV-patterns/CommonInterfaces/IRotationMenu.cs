using System;
using UnityEngine;

public interface IRotationMenu
{
    event Action<Vector3> OnRotateRequested;
    Transform RotateObject { get; }
}
