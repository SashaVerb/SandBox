using UnityEngine;

public class MVVM_PrefabRotationView : MVVM_RotationView
{
    private Transform _prefabTransform;
    private RotateButton[] _rotateButtons;

    public MVVM_PrefabRotationView(GameObject prefab, RotateButton[] rotateButtons, MVVM_RotationViewModel viewModel) : base(viewModel)
    {
        if (prefab)
            _prefabTransform = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity).transform;

        _rotateButtons = rotateButtons;
        foreach (var button in _rotateButtons)
        {
            button.OnRotate += _viewModel.Rotate;
        }
    }

    public override void Clear()
    {
        foreach (var button in _rotateButtons)
        {
            button.OnRotate -= _viewModel.Rotate;
        }
        Object.Destroy(_prefabTransform.gameObject);
    }

    public override void SetRotation(Quaternion rotation)
    {
        if(_prefabTransform)
            _prefabTransform.rotation = rotation;
    }
}
