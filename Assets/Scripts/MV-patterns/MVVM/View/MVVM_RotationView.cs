using R3;
using UnityEngine;

public abstract class MVVM_RotationView
{
    protected MVVM_RotationViewModel _viewModel;

    protected MVVM_RotationView(MVVM_RotationViewModel viewModel)
    {
        _viewModel = viewModel;

        _viewModel.RotationView.Subscribe(SetRotation);
    }

    public abstract void SetRotation(Quaternion rotation);

    public abstract void Clear();
}
