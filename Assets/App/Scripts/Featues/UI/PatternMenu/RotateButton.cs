using System;
using UnityEngine;

public class RotateButton : HoldButton
{
    public Action<Vector3> OnRotate;

    [SerializeField] private Vector3 _rotationAxis;

    private void OnEnable()
    {
        OnHold += OnRotateRequested;
    }

    private void OnDisable()
    {
        OnHold -= OnRotateRequested;
    }

    private void OnRotateRequested()
    {
        OnRotate?.Invoke(_rotationAxis);
    }
}
