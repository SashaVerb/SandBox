using UnityEngine;

public class MVVM_Bootstrap : MonoBehaviour, IBootstrap
{
    [SerializeField] private RotateButton[] buttons;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _prefab;

    private MVVM_PrefabRotationView _view;
    private MVVM_RotationWithSpeedModel _model;
    private MVVM_RotationViewModel _viewModel;

    public void Init()
    {
        _model = new MVVM_RotationWithSpeedModel(_speed);
        _viewModel = new MVVM_FreeRotationViewModel(_model);
        _view = new MVVM_PrefabRotationView(_prefab, buttons, _viewModel);
    }

    public void Dispose()
    {
        _view.Dispose();
        _viewModel.Dispose();
    }
}
