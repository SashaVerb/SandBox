using UnityEngine;

public class MVP_Bootstrap : MonoBehaviour, IBootstrap
{
    [SerializeField] private RotateButton[] buttons;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _prefab;

    private MVP_PrefabRotationView _view;
    private MVP_RotationWithSpeedModel _model;
    private MVP_RotationPresenter _presenter;

    public void Init()
    {
        _model = new MVP_RotationWithSpeedModel(_speed);
        _presenter = new MVP_FreeRotationPresenter(_model);
        _view = new MVP_PrefabRotationView(_prefab, buttons, _presenter);
        _model.Init(_view);
    }

    public void Dispose()
    {
        _view.Clear();
    }
}
