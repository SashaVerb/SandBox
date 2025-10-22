using UnityEngine;

public class MVP_FreeRotationController : MVP_RotationPresenter
{
    public MVP_FreeRotationController(MVP_RotationModel model) : base(model)
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
