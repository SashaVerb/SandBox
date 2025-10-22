using System;
using UnityEngine;

public class MVVM_PrefabRotationView : MVVM_RotationView
{
    private Transform _prefabTransform;
    private RotateButton[] _rotateButtons;

    public MVVM_PrefabRotationView(GameObject prefab, RotateButton[] rotateButtons, MVVM_RotationViewModel viewModel) : base(viewModel)
    {
        if (prefab)
            _prefabTransform = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity).transform;
        else
            throw new ArgumentNullException($"Prefab is not assigned in {nameof(MVVM_PrefabRotationView)}");

        _rotateButtons = rotateButtons;
        foreach (var button in _rotateButtons)
        {
            button.OnRotate += _viewModel.Rotate;
        }
    }

    public override void Dispose()
    {
        base.Dispose();
        foreach (var button in _rotateButtons)
        {
            button.OnRotate -= _viewModel.Rotate;
        }
        GameObject.Destroy(_prefabTransform.gameObject);
    }

    public override void SetRotation(Quaternion rotation)
    {
        if(_prefabTransform)
            _prefabTransform.rotation = rotation;
    }
}
