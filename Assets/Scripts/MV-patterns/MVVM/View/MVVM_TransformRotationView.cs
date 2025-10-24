using R3;
using UnityEngine;
using UnityEngine.UIElements;

public class MVVM_TransformRotationView : MVVM_IRotationView
{
    private Transform _transform;
    private RotateButton[] _rotateButtons;

    private MVVM_IRotationViewModel _viewModel;
    private CompositeDisposable _disposables = new();

    public MVVM_TransformRotationView(Transform transform, RotateButton[] rotateButtons, MVVM_IRotationViewModel viewModel)
    {
        _viewModel = viewModel;
        
        _transform = transform;

        _rotateButtons = rotateButtons;
        foreach (var button in _rotateButtons)
        {
            button.OnRotate += _viewModel.Rotate;
        }

        _disposables.Add(_viewModel.RotationView.Subscribe(SetRotation));
    }

    public void Dispose()
    {
        foreach (var button in _rotateButtons)
        {
            button.OnRotate -= _viewModel.Rotate;
        }

        _disposables.Dispose();
    }

    public void SetRotation(Quaternion rotation)
    {
        _transform.rotation = rotation;
    }
}
