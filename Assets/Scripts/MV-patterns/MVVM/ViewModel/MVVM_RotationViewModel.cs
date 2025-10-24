using R3;
using UnityEngine;

public class MVVM_RotationViewModel : MVVM_IRotationViewModel
{
    private MVVM_IRotationModel _model;
    private CompositeDisposable _disposables = new();

    public ReactiveProperty<Quaternion> RotationView => new(Quaternion.identity);

    public MVVM_RotationViewModel(MVVM_IRotationModel model)
    {
        _model = model;

        _model.Rotation.Subscribe(OnRotationChange).AddTo(_disposables);
    }

    private void OnRotationChange(Quaternion quaternion)
    {
        RotationView.Value = quaternion;
    }

    public void Rotate(Vector3 axis)
    {
        _model.Rotate(axis);
    }

    public void SetRotation(Quaternion rotation)
    {
        _model.Rotation.Value = rotation;
    }

    public void Dispose()
    {
        _disposables.Dispose();
    }
}
