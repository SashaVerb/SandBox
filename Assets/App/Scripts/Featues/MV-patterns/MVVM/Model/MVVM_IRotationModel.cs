using UnityEngine;
using R3;

public interface MVVM_IRotationModel
{
    public ReactiveProperty<Quaternion> Rotation { get; }

    public abstract void Rotate(Vector3 axis);
}
