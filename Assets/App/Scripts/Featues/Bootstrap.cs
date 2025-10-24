using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private PatternMenuView _patternMenuView;
    [SerializeField] private PatternSwitchMenuView _patternSwitchMenuView;
    [Space]
    [Header("Patterns")]
    [SerializeField] private MVC_Bootstrap _mvc;
    [SerializeField] private MVP_Bootstrap _mvp;
    [SerializeField] private MVVM_Bootstrap _mvvm;

    private ISwitchable _currentBootstrap;

    private Dictionary<string, ISwitchable> _bootstraps;

    private GenericSwitchMachine<ISwitchable> _viewSwitcher;

    private void Awake()
    {
        _bootstraps = new Dictionary<string, ISwitchable> {
            { "MVC", _mvc },
            { "MVP", _mvp },
            { "MVVM", _mvvm }
        };


        _patternSwitchMenuView.SetOptions(_bootstraps.Keys.ToList());
        _patternSwitchMenuView.OnChoosePattern += OnActivatePattern;
        
        _patternMenuView.OnGoBack += OnGoBack;
        _viewSwitcher = new(_patternMenuView, _patternSwitchMenuView);

        _viewSwitcher.SwitchTo<PatternSwitchMenuView>();
    }

    private void OnActivatePattern(string pattern)
    {
        if (_bootstraps.TryGetValue(pattern, out var bootstrap))
        {
            _currentBootstrap = bootstrap;
        }
        else
        {
            Debug.LogError($"No such option: {pattern}");
            return;
        }

        _viewSwitcher.SwitchTo<PatternMenuView>();

        _currentBootstrap.Activate();
    }

    private void OnGoBack()
    {
        _viewSwitcher.SwitchTo<PatternSwitchMenuView>();

        _currentBootstrap.Deactivate();
    }
}
