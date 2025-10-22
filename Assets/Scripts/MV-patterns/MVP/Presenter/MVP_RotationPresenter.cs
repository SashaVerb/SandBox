using UnityEngine;

public abstract class MVP_RotationPresenter
{
    protected MVP_RotationModel _model;

    public MVP_RotationPresenter(MVP_RotationModel model)
    {
        _model = model;
    }

    public abstract void Rotate(Vector3 axis);
    public abstract void SetRotation(Quaternion rotation);
}
