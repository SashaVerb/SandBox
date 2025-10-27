using R3;
using UnityEngine;

public class MVP_RotationPresenter : MVP_IRotationPresenter
{
    private readonly MVP_IRotationModel _model;
    private readonly MVP_IRotationView _view;

    private readonly CompositeDisposable _disposables = new();

    public MVP_RotationPresenter(MVP_IRotationModel model, MVP_IRotationView view)
    {
        _model = model;
        _view = view;
    }

    public void Rotate(Vector3 axis)
    {
        _model.Rotate(axis);
    }

    public void SetRotation(Quaternion rotation)
    {
        _model.SetRotation(rotation);
    }

    public void Subscribe()
    {
        _model.Rotation.Subscribe(_view.SetRotation).AddTo(_disposables);

        _view.OnRotate += Rotate;
    }

    public void Unsubscribe()
    {
        _disposables.Clear();

        _view.OnRotate -= Rotate;
    }
}
