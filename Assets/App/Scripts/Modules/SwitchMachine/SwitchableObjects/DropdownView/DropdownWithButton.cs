using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[SelectionBase]
public class DropdownWithButton : SwitchableUIView, IDropdown
{
    [SerializeField] private TMP_Dropdown _dropdown;
    [SerializeField] private Button _acceptButton;

    public event Action<string> OnChooseOption;

    private void OnEnable()
    {
        _acceptButton.onClick.AddListener(HandleButtonClick);
    }

    private void OnDisable()
    {
        _acceptButton.onClick.RemoveListener(HandleButtonClick);
    }

    public string CurrentOption => _dropdown.options[_dropdown.value].text;

    public void SetOptions(List<string> options)
    {

        _dropdown.ClearOptions();
        _dropdown.AddOptions(options);
    }

    private void HandleButtonClick()
    {
        OnChooseOption.Invoke(CurrentOption);
    }
}
