using System;
using UnityEngine;

public interface MVP_IRotationPresenter : ISubscribable
{
    void Rotate(Vector3 axis);
    void SetRotation(Quaternion rotation);
}
