using R3;
using UnityEngine;

public interface MVVM_IRotationViewModel : ISubscriable
{
    public ReactiveProperty<Quaternion> RotationView { get; }

    void Rotate(Vector3 axis);
    void SetRotation(Quaternion rotation);
}
