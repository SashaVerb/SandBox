using UnityEngine;

public class MVC_Switcher : ISwitchable
{
    private float _speed;
    private readonly IPatternMenuView _patternView;
    
    private readonly MVC_IRotationView _view;
    private readonly MVC_IRotationModel _model;
    private readonly MVC_IRotationController _controller;

    public MVC_Switcher(IPatternMenuView patternView, float speed)
    {
        _patternView = patternView;
        _speed = speed;

        _view = new MVC_TransformRotationView(patternView.RotateObject);
        _model = new MVC_RotationWithSpeedModel(_speed);
        _controller = new MVC_RotationController(_view, _model);
    }

    public void Activate()
    {
        _model.SetRotation(Quaternion.identity);
        _patternView.OnRotateRequested += Rotate;
        _controller.Subscribe();
    }

    public void Deactivate()
    {
        _patternView.OnRotateRequested -= Rotate;
        _controller.Unsubscribe();
    }

    private void Rotate(Vector3 vector)
    {
        _controller.Rotate(vector);
    }
}
