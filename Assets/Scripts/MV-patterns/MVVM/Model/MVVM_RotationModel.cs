using UnityEngine;
using R3;

public abstract class MVVM_RotationModel
{
    public readonly ReactiveProperty<Quaternion> Rotation = new();

    protected MVVM_RotationModel()
    {
        Rotation.Value = Quaternion.identity;
    }

    protected MVVM_RotationModel(Quaternion initialRotation)
    {
        Rotation.Value = initialRotation;
    }

    public abstract void Rotate(Vector3 axis);
    public abstract void SetRotation(Quaternion rotation);
}
