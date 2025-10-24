using System;
using UnityEngine;

public interface MVP_IRotationPresenter : IDisposable
{
    public abstract void Rotate(Vector3 axis);
    public abstract void SetRotation(Quaternion rotation);
}
