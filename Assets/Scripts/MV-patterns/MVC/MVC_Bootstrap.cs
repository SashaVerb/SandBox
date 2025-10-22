using UnityEngine;

public class MVC_Bootstrap : MonoBehaviour, IBootstrap
{
    [SerializeField] private RotateButton[] buttons;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _prefab;

    private MVC_PrefabRotationView _view;
    private MVC_RotationWithSpeedModel _model;
    private MVC_RotationController _controller;

    public void Init()
    {
        _view = new MVC_PrefabRotationView(_prefab);
        _model = new MVC_RotationWithSpeedModel(_view, _speed);
        _controller = new MVC_FreeRotationController(_view, _model);

        foreach (var button in buttons)
        {
            button.OnRotate += Rotate;
        }
    }

    public void Dispose()
    {
        _view.Clear();

        foreach (var button in buttons)
        {
            button.OnRotate -= Rotate;
        }
    }

    private void Rotate(Vector3 vector)
    {
        _controller.Rotate(vector);
    }
}
