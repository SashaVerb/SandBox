using System;
using UnityEngine;

public class MVP_TransformRotationView : MVP_IRotationView
{
    private Transform _transform;
    private RotateButton[] _rotateButtons;

    public MVP_TransformRotationView(Transform transform, RotateButton[] rotateButtons)
    {
        _transform = transform;

        _rotateButtons = rotateButtons;
        foreach (var button in _rotateButtons)
        {
            button.OnRotate += HandleButtonRotate;
        }
    }

    public event Action<Vector3> OnRotate;

    public void Dispose()
    {
        foreach (var button in _rotateButtons)
        {
            button.OnRotate -= OnRotate;
        }

        GameObject.Destroy(_transform.gameObject);
    }

    public void SetRotation(Quaternion rotation)
    {
        _transform.rotation = rotation;
    }

    private void HandleButtonRotate(Vector3 vector)
    {
        OnRotate?.Invoke(vector);
    }
}
