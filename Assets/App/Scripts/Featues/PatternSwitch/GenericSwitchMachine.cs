using System;
using System.Collections.Generic;

public class GenericSwitchMachine<TValue> where TValue : ISwitchable
{
    private readonly Dictionary<Type, TValue> _dictionary;
    public TValue CurrentValue { get; private set; }
    public Type CurrentType { get; private set; }

    public GenericSwitchMachine(params TValue[] switches)
    {
        _dictionary = new Dictionary<Type, TValue>();
        foreach (var sw in switches)
        {
            _dictionary[sw.GetType()] = sw;
        }
    }

    public void SwitchTo<T>() where T : ISwitchable
    {
        var type = typeof(T);

        if (CurrentType == type)
            return;

        if (!_dictionary.TryGetValue(type, out var newSwitch))
            throw new KeyNotFoundException($"No switchable found for type '{type.Name}'");

        CurrentValue?.Deactivate();

        newSwitch.Activate();

        CurrentValue = newSwitch;
        CurrentType = type;
    }

    public void DeactivateCurrent()
    {
        CurrentValue?.Deactivate();

        CurrentValue = default;
        CurrentType = null;
    }
}