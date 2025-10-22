using UnityEngine;

public class MVP_PrefabRotationView : MVP_RotationView
{
    private Transform _prefabTransform;
    private RotateButton[] _rotateButtons;

    public MVP_PrefabRotationView(GameObject prefab, RotateButton[] rotateButtons, MVP_RotationPresenter presenter) : base(presenter)
    {
        if (prefab)
            _prefabTransform = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity).transform;

        _rotateButtons = rotateButtons;
        foreach (var button in _rotateButtons)
        {
            button.OnRotate += _presenter.Rotate;
        }
    }

    public override void Clear()
    {
        foreach (var button in _rotateButtons)
        {
            button.OnRotate -= _presenter.Rotate;
        }

        GameObject.Destroy(_prefabTransform.gameObject);
    }

    public override void SetRotation(Quaternion rotation)
    {
        _prefabTransform.rotation = rotation;
    }
}
