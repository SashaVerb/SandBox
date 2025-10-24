using System;
using System.Collections.Generic;
using UnityEngine;

public class PatternSwitchMenuView : SwitchableUIView, IPatternSwitchMenuView
{
    [SerializeField] private DropdownWithButton _dropdown;

    private void OnEnable()
    {
        _dropdown.OnChooseOption += HandleChooseOption;
    }

    private void OnDisable()
    {
        _dropdown.OnChooseOption -= HandleChooseOption;
    }

    public event Action<string> OnChoosePattern;

    public void SetOptions(List<string> options)
    {
        _dropdown.SetOptions(options);
    }

    private void HandleChooseOption(string option)
    {
        OnChoosePattern?.Invoke(option);
    }
}
