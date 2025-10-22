using R3;
using System;
using UnityEngine;

public abstract class MVVM_RotationViewModel : IDisposable
{
    public ReactiveProperty<Quaternion> RotationView = new();
    
    protected MVVM_RotationModel _model;
    protected CompositeDisposable _disposables = new();

    protected MVVM_RotationViewModel(MVVM_RotationModel model)
    {
        _model = model;

        _disposables.Add(_model.Rotation.Subscribe(OnRotationChange));
    }

    private void OnRotationChange(Quaternion quaternion)
    {
        RotationView.Value = quaternion;
    }

    public abstract void Rotate(Vector3 axis);
    public abstract void SetRotation(Quaternion rotation);

    public void Dispose()
    {
        _disposables.Dispose();
    }
}
