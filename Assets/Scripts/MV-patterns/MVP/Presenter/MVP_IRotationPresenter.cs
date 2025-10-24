using System;
using UnityEngine;

public interface MVP_IRotationPresenter : IDisposable
{
    void Rotate(Vector3 axis);
    void SetRotation(Quaternion rotation);
}
