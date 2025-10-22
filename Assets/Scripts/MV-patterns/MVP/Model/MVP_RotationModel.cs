using UnityEngine;

public abstract class MVP_RotationModel
{
    protected MVP_RotationView _view;
    private Quaternion _rotation;
    protected Quaternion Rotation
    {
        get => _rotation;
        set
        {
            _rotation = value;
            _view.SetRotation(_rotation);
        }
    }

    protected MVP_RotationModel()
    {
        _rotation = Quaternion.identity;
    }

    protected MVP_RotationModel(Quaternion rotation)
    {
        _rotation = rotation;
    }

    public void Init(MVP_RotationView view)
    {
        _view = view;
    }

    public abstract void Rotate(Vector3 axis);

    public abstract void SetRotation(Quaternion rotation);
}
