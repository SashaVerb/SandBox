using System;
using UnityEngine;

public interface MVC_IRotationController : IDisposable
{
    void Rotate(Vector3 axis);
    void SetRotation(Quaternion rotation);
}
