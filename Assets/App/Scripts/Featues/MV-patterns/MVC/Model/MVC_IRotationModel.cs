using R3;
using UnityEngine;

public interface MVC_IRotationModel
{
    ReactiveProperty<Quaternion> Rotation { get; }

    void Rotate(Vector3 axis);
}
