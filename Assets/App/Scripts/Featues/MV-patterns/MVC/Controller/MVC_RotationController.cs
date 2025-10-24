using R3;
using UnityEngine;

public class MVC_RotationController : MVC_IRotationController
{
    private readonly MVC_IRotationView _view;
    private readonly MVC_IRotationModel _model;

    private CompositeDisposable _disposables = new();

    public MVC_RotationController(MVC_IRotationView view, MVC_IRotationModel model)
    {
        _view = view;
        _model = model;

        _model.Rotation.Subscribe(_view.SetRotation).AddTo(_disposables);
    }

    public void Dispose()
    {
        _disposables.Dispose();
    }

    public void Rotate(Vector3 axis)
    {
        _model.Rotate(axis);
    }

    public void SetRotation(Quaternion rotation)
    {
        _model.Rotation.Value = rotation;
    }
}
