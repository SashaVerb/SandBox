using UnityEngine;

public class MVP_RotationWithSpeedModel : MVP_RotationModel
{
    public float Speed { get; set; }

    public MVP_RotationWithSpeedModel(float speed = 1f)
    {
        Speed = speed;
    }

    public override void Rotate(Vector3 axis)
    {
        Quaternion scaledRotation = Quaternion.AngleAxis(Speed * Time.deltaTime, axis);

        Rotation *= scaledRotation;
    }

    public override void SetRotation(Quaternion rotation)
    {
        Rotation = rotation;
    }
}
