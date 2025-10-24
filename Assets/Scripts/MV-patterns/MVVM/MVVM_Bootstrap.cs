using UnityEngine;

public class MVVM_Bootstrap : MonoBehaviour, IBootstrap
{
    [SerializeField] private RotateButton[] buttons;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _prefab;

    private MVVM_IRotationView _view;
    private MVVM_IRotationModel _model;
    private MVVM_IRotationViewModel _viewModel;

    private GameObject _rotateObject;

    public void Init()
    {
        _rotateObject = Instantiate(_prefab);

        _model = new MVVM_RotationWithSpeedModel(_speed);
        _viewModel = new MVVM_RotationViewModel(_model);
        _view = new MVVM_TransformRotationView(_rotateObject.transform, buttons, _viewModel);
    }

    public void Dispose()
    {
        _view.Dispose();
        _viewModel.Dispose();

        GameObject.Destroy(_rotateObject);
    }
}
