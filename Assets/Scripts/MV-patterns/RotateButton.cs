using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RotateButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Action<Vector3> OnRotate;

    [SerializeField] private Vector3 _rotationAxis;
    [SerializeField] private Button _button;

    private bool _isHolding = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        _isHolding = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isHolding = false;
    }

    private void Update()
    {
        if (_isHolding)
        {
            OnRotate?.Invoke(_rotationAxis);
        }
    }
}
