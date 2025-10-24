using R3;
using System;
using UnityEngine;

public interface MVVM_IRotationViewModel : IDisposable
{
    public ReactiveProperty<Quaternion> RotationView { get; }

    void Rotate(Vector3 axis);
    void SetRotation(Quaternion rotation);
}
