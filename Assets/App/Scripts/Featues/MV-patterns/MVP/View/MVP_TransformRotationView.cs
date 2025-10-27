using System;
using UnityEngine;

public class MVP_TransformRotationView : MVP_IRotationView
{
    private IRotationMenu _rotationMenu;

    public MVP_TransformRotationView(IRotationMenu rotationMenu)
    {
        _rotationMenu = rotationMenu;
    }

    public event Action<Vector3> OnRotate;

    public void SetRotation(Quaternion rotation)
    {
        _rotationMenu.RotateObject.rotation = rotation;
    }

    public void Subscribe()
    {
        _rotationMenu.OnRotateRequested += HandleButtonRotate;
    }

    public void Unsubscribe()
    {
        _rotationMenu.OnRotateRequested -= HandleButtonRotate;
    }

    private void HandleButtonRotate(Vector3 vector)
    {
        OnRotate?.Invoke(vector);
    }
}
