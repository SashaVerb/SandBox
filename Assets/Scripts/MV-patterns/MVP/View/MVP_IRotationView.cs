using System;
using UnityEngine;

public interface MVP_IRotationView : IDisposable
{
    event Action<Vector3> OnRotate;
    void SetRotation(Quaternion rotation);
}
