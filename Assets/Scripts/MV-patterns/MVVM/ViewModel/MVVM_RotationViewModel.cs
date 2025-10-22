using R3;
using UnityEngine;

public abstract class MVVM_RotationViewModel
{
    protected MVVM_RotationModel _model;

    public ReactiveProperty<Quaternion> RotationView = new();

    protected MVVM_RotationViewModel(MVVM_RotationModel model)
    {
        _model = model;

        _model.Rotation.Subscribe(OnRotationChange);
    }

    private void OnRotationChange(Quaternion quaternion)
    {
        RotationView.Value = quaternion;
    }

    public abstract void Rotate(Vector3 axis);
    public abstract void SetRotation(Quaternion rotation);
}
