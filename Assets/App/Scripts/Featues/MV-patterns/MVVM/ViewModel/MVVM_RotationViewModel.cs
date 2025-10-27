using R3;
using UnityEngine;

public class MVVM_RotationViewModel : MVVM_IRotationViewModel
{
    private readonly MVVM_IRotationModel _model;
    private readonly CompositeDisposable _disposables = new();

    public ReactiveProperty<Quaternion> RotationView { get; }

    public MVVM_RotationViewModel(MVVM_IRotationModel model)
    {
        _model = model;
        RotationView = new(model.Rotation.Value);
    }

    public void Rotate(Vector3 axis)
    {
        _model.Rotate(axis);
    }

    public void SetRotation(Quaternion rotation)
    {
        _model.SetRotation(rotation);
    }

    public void Subscribe()
    {
        _model.Rotation.Subscribe(OnRotationChange).AddTo(_disposables);
    }

    public void Unsubscribe()
    {
        _disposables.Clear();
    }

    private void OnRotationChange(Quaternion quaternion)
    {
        RotationView.Value = quaternion;
    }
}
