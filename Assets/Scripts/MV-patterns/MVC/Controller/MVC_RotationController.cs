using UnityEngine;

public abstract class MVC_RotationController
{
    protected MVC_RotationView _view;
    protected MVC_RotationModel _model;

    public MVC_RotationController(MVC_RotationView view, MVC_RotationModel model)
    {
        _view = view;
        _model = model;
    }

    public abstract void Rotate(Vector3 axis);
    public abstract void SetRotation(Quaternion rotation);
}
