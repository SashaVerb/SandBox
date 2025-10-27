using UnityEngine;

public class MVC_Switcher : ISwitchable
{
    private IPatternMenuView _patternView;
    private float _speed;

    private MVC_IRotationView _view;
    private MVC_IRotationModel _model;
    private MVC_IRotationController _controller;

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
        _patternView.OnRotateRequested += Rotate;
        _model.Rotation.Value = Quaternion.identity;
    }

    public void Deactivate()
    {
        _patternView.OnRotateRequested -= Rotate;
    }

    private void Rotate(Vector3 vector)
    {
        _controller.Rotate(vector);
    }
}
