using UnityEngine;

public abstract class MVC_RotationModel
{
    protected MVC_RotationView _view;
    private Quaternion _rotation;
    protected Quaternion Rotation
    {
        get => _rotation;
        set {
            _rotation = value;
            _view.SetRotation(_rotation);
        }
    }

    protected MVC_RotationModel(MVC_RotationView view)
    {
        _view = view;
        _rotation = Quaternion.identity;
    }

    protected MVC_RotationModel(MVC_RotationView view, Quaternion rotation)
    {
        _view = view;
        _rotation = rotation;
    }

    public abstract void Rotate(Vector3 axis);

    public abstract void SetRotation(Quaternion rotation);
}
