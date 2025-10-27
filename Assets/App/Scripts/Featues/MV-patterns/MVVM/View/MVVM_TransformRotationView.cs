using R3;
using UnityEngine;

public class MVVM_TransformRotationView : MVVM_IRotationView
{
    private readonly MVVM_IRotationViewModel _viewModel;
    private readonly IRotationMenu _rotationMenu;

    private readonly CompositeDisposable _disposables = new();

    public MVVM_TransformRotationView(IRotationMenu rotationMenu, MVVM_IRotationViewModel viewModel)
    {
        _viewModel = viewModel;
        _rotationMenu = rotationMenu;
    }

    public void SetRotation(Quaternion rotation)
    {
        _rotationMenu.RotateObject.rotation = rotation;
    }

    public void Subscribe()
    {
        _rotationMenu.OnRotateRequested += _viewModel.Rotate;

        _disposables.Add(_viewModel.RotationView.Subscribe(SetRotation));
    }

    public void Unsubscribe()
    {
        _rotationMenu.OnRotateRequested -= _viewModel.Rotate;

        _disposables.Clear();
    }
}
