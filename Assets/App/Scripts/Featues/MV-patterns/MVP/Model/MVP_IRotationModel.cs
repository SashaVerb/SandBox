using R3;
using UnityEngine;

public interface MVP_IRotationModel
{
    ReactiveProperty<Quaternion> Rotation { get; }

    void Rotate(Vector3 axis);

    void SetRotation(Quaternion rotation);
}
