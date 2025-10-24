using UnityEngine;

public class MVP_Bootstrap : MonoBehaviour, ISwitchable
{
    [SerializeField] private RotateButton[] buttons;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _prefab;

    private MVP_IRotationView _view;
    private MVP_IRotationModel _model;
    private MVP_IRotationPresenter _presenter;

    private GameObject _rotateObject;

    public void Activate()
    {
        _rotateObject = Instantiate(_prefab);

        _model = new MVP_RotationWithSpeedModel(_speed);
        _view = new MVP_TransformRotationView(_rotateObject.transform, buttons);
        _presenter = new MVP_RotationPresenter(_model, _view);
    }

    public void Deactivate()
    {
        _presenter.Dispose();

        Destroy(_rotateObject);
    }
}
