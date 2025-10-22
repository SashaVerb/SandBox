using R3;
using System;
using UnityEngine;

public abstract class MVVM_RotationView : IDisposable
{
    protected MVVM_RotationViewModel _viewModel;
    protected CompositeDisposable disposables = new();

    protected MVVM_RotationView(MVVM_RotationViewModel viewModel)
    {
        _viewModel = viewModel;

        disposables.Add(_viewModel.RotationView.Subscribe(SetRotation));
    }

    public abstract void SetRotation(Quaternion rotation);

    public virtual void Dispose()
    {
        disposables.Dispose();
    }
}
