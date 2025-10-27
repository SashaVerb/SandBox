using System;
using UnityEngine;
using UnityEngine.UI;

public class PatternMenuView : SwitchableUIView, IPatternMenuView
{
    [SerializeField] private Button _backButton;
    [SerializeField] private RotateButton[] _rotateButtons;
    [SerializeField] private GameObject _rotateObject;

    public Transform RotateObject => _rotateObject.transform;

    public event Action<Vector3> OnRotateRequested;
    public event Action OnGoBack;

    private void OnEnable()
    {
        _backButton.onClick.AddListener(HandleOnGoBack);

        foreach (var button in _rotateButtons)
        {
            button.OnRotate += HandleOnRotate;
        }
    }

    private void OnDisable()
    {
        _backButton.onClick.RemoveListener(HandleOnGoBack);

        foreach (var button in _rotateButtons)
        {
            button.OnRotate -= HandleOnRotate;
        }
    }

    private void HandleOnGoBack()
    {
        OnGoBack?.Invoke();
    }

    private void HandleOnRotate(Vector3 axis)
    {
        OnRotateRequested?.Invoke(axis);
    }

    public override void Activate()
    {
        _rotateObject.SetActive(true);
        base.Activate();
    }

    public override void Deactivate()
    {
        _rotateObject.SetActive(false);
        base.Deactivate();
    }
}
