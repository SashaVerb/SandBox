using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private PatternMenuView _patternMenuView;
    [SerializeField] private PatternSwitchMenuView _patternSwitchMenuView;
    [Space]
    [SerializeField] private float _speed;

    private Dictionary<string, ISwitchable> _patternsDictionary;

    private SwitchMachine<string, ISwitchable> _patternsSwitcher;

    private GenericSwitchMachine<ISwitchable> _viewSwitcher;

    private void Awake()
    {
        SetPatterns();
        Subscribe();
        SetUIViews();
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void SetPatterns()
    {
        _patternsDictionary = new Dictionary<string, ISwitchable> {
            { "MVC", new MVC_Switcher(_patternMenuView, _speed) },
            { "MVP", new MVP_Switcher(_patternMenuView, _speed) },
            { "MVVM", new MVVM_Switcher(_patternMenuView, _speed) }
        };

        _patternsSwitcher = new(_patternsDictionary);
        _patternSwitchMenuView.SetOptions(_patternsDictionary.Keys.ToList());
    }

    private void Subscribe()
    {
        _patternSwitchMenuView.OnChoosePattern += OnActivatePattern;
        _patternMenuView.OnGoBack += OnGoBack;
    }

    private void Unsubscribe()
    {
        _patternSwitchMenuView.OnChoosePattern -= OnActivatePattern;
        _patternMenuView.OnGoBack -= OnGoBack;
    }

    private void SetUIViews()
    {
        _viewSwitcher = new(_patternMenuView, _patternSwitchMenuView);
        _viewSwitcher.SwitchTo<PatternSwitchMenuView>();
    }

    private void OnActivatePattern(string pattern)
    {
        _patternsSwitcher.SwitchTo(pattern);
        _viewSwitcher.SwitchTo<PatternMenuView>();
    }

    private void OnGoBack()
    {
        _viewSwitcher.SwitchTo<PatternSwitchMenuView>();
        _patternsSwitcher.DeactivateCurrent();
    }
}
