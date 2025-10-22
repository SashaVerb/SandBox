using UnityEngine;

public class MVVM_RotationWithSpeedModel : MVVM_RotationModel
{
    public float Speed { get; set; }

    public MVVM_RotationWithSpeedModel(float speed = 1f)
    {
        Speed = speed;
    }

    public override void Rotate(Vector3 axis)
    {
        Quaternion scaledRotation = Quaternion.AngleAxis(Speed * Time.deltaTime, axis);

        Rotation.Value *= scaledRotation;
    }

    public override void SetRotation(Quaternion rotation)
    {
        Rotation.Value = rotation;
    }
}
