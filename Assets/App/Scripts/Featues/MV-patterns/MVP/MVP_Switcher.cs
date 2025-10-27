using UnityEngine;

public class MVP_Switcher : ISwitchable
{
    private float _speed;
    private readonly IPatternMenuView _patternView;

    private readonly MVP_IRotationView _view;
    private readonly MVP_IRotationModel _model;
    private readonly MVP_IRotationPresenter _presenter;

    public MVP_Switcher(IPatternMenuView patternView, float speed)
    {
        _patternView = patternView;
        _speed = speed;

        _model = new MVP_RotationWithSpeedModel(_speed);
        _view = new MVP_TransformRotationView(_patternView);
        _presenter = new MVP_RotationPresenter(_model, _view);
    }

    public void Activate()
    {
        _model.SetRotation(Quaternion.identity);
        _presenter.Subscribe();
        _view.Subscribe();
    }

    public void Deactivate()
    {
        _presenter.Unsubscribe();
        _view.Unsubscribe();
    }
}
