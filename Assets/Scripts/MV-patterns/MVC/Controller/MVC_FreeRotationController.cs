using UnityEngine;

public class MVC_FreeRotationController : MVC_RotationController
{
    public MVC_FreeRotationController(MVC_RotationView view, MVC_RotationModel model) : base(view, model)
    {
    }

    public override void Rotate(Vector3 axis)
    {
        _model.Rotate(axis);
    }

    public override void SetRotation(Quaternion rotation)
    {
        _model.SetRotation(rotation);
    }
}
