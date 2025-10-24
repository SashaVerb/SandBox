using R3;
using UnityEngine;

public class MVP_RotationWithSpeedModel : MVP_IRotationModel
{
    public float Speed { get; set; }

    public ReactiveProperty<Quaternion> Rotation => new(Quaternion.identity);

    public MVP_RotationWithSpeedModel(float speed = 1f)
    {
        Speed = speed;
    }

    public void Rotate(Vector3 axis)
    {
        Quaternion scaledRotation = Quaternion.AngleAxis(Speed * Time.deltaTime, axis);

        Rotation.Value *= scaledRotation;
    }

    public void SetRotation(Quaternion rotation)
    {
        Rotation.Value = rotation;
    }
}
