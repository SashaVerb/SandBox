using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PatternSwitch : MonoBehaviour
{
    [Header("Switch Menu")]
    [SerializeField] private GameObject _patternSwitchMenuRoot;
    [SerializeField] private TMP_Dropdown _dropdown;
    [SerializeField] private Button _startButton;
    [Space]
    [Header("Pattern Menu")]
    [SerializeField] private GameObject _patternMenuRoot;
    [SerializeField] private Button _backButton;
    [SerializeField] private GameObject _rotateButtons;
    [Space]
    [Header("Bootstraps")]
    [SerializeField] private MVC_Bootstrap _mvc;
    [SerializeField] private MVP_Bootstrap _mvp;
    [SerializeField] private MVVM_Bootstrap _mvvm;

    private ISwitchable _currentBootstrap;

    private Dictionary<string, ISwitchable> _bootstraps;
    private List<string> _options;
    private void Awake()
    {
        _bootstraps = new Dictionary<string, ISwitchable> {
            { "MVC", _mvc },
            { "MVP", _mvp },
            { "MVVM", _mvvm }
        };

        _options = _bootstraps.Keys.ToList();

        _dropdown.ClearOptions();
        _dropdown.AddOptions(_options);

        _startButton.onClick.AddListener(OnActivatePattern);

        _backButton.onClick.AddListener(OnGoBack);

        PatternSwitchMenuIsShown(true);
    }

    private void OnActivatePattern()
    {
        string option = _options[_dropdown.value];

        if(_bootstraps.TryGetValue(option, out var bootstrap))
        {
            _currentBootstrap = bootstrap;
        }
        else
        {
            Debug.LogError($"No such option: {option}");
            return;
        }

        PatternSwitchMenuIsShown(false);

        _currentBootstrap.Activate();
    }

    private void OnGoBack()
    {
        PatternSwitchMenuIsShown(true);

        _currentBootstrap.Deactivate();
    }

    private void PatternSwitchMenuIsShown(bool isShown)
    {
        _patternSwitchMenuRoot.SetActive(isShown);
        _patternMenuRoot.SetActive(!isShown);
    }
}
