using UnityEngine;

public class MVC_RotationWithSpeedModel : MVC_RotationModel
{
    public float Speed { get; set; }

    public MVC_RotationWithSpeedModel(MVC_RotationView view, float speed = 1f) : base(view)
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
