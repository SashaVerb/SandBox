using System;
using UnityEngine;

public interface MVVM_IRotationView : IDisposable
{
    void SetRotation(Quaternion rotation);
}
