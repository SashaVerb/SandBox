using UnityEngine;
using R3;

public interface MVVM_IRotationModel
{
    public ReactiveProperty<Quaternion> Rotation { get; }

    void Rotate(Vector3 axis);

    void SetRotation(Quaternion rotation);
}
