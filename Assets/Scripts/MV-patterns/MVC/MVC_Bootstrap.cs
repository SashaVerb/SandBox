using UnityEngine;

public class MVC_Bootstrap : MonoBehaviour, IBootstrap
{
    [SerializeField] private RotateButton[] _buttons;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _prefab;

    private MVC_IRotationView _view;
    private MVC_IRotationModel _model;
    private MVC_IRotationController _controller;

    private GameObject _rotateObject;

    public void Init()
    {
        _rotateObject = Instantiate(_prefab);

        _view = new MVC_TransformRotationView(_rotateObject.transform);
        _model = new MVC_RotationWithSpeedModel(_speed);
        _controller = new MVC_RotationController(_view, _model);

        foreach (var button in _buttons)
        {
            button.OnRotate += Rotate;
        }
    }

    public void Dispose()
    {
        _controller.Dispose();

        foreach (var button in _buttons)
        {
            button.OnRotate -= Rotate;
        }

        Destroy(_rotateObject);
    }

    private void Rotate(Vector3 vector)
    {
        _controller.Rotate(vector);
    }
}
