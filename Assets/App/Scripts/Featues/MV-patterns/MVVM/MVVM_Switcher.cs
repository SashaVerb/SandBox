using UnityEngine;

public class MVVM_Switcher : ISwitchable
{
    private float _speed;
    private IPatternMenuView _patternView;

    private MVVM_IRotationView _view;
    private MVVM_IRotationModel _model;
    private MVVM_IRotationViewModel _viewModel;

    public MVVM_Switcher(IPatternMenuView patternView, float speed)
    {
        _patternView = patternView;
        _speed = speed;

        _model = new MVVM_RotationWithSpeedModel(_speed);
        _viewModel = new MVVM_RotationViewModel(_model);
        _view = new MVVM_TransformRotationView(_patternView, _viewModel);
    }

    public void Activate()
    {
        _model.Rotation.Value = Quaternion.identity;
        _viewModel.Subscribe();
        _view.Subscribe();
    }

    public void Deactivate()
    {
        _viewModel.Unsubscribe();
        _view.Unsubscribe();
    }
}
