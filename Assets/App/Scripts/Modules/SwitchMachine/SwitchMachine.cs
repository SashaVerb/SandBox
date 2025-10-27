using System.Collections.Generic;

public class SwitchMachine<TKey, TValue> where TValue : ISwitchable
{
    private readonly Dictionary<TKey, TValue> _dictionary;
    public TValue CurrentValue { get; private set; }
    public TKey CurrentKey { get; private set; }

    public SwitchMachine(Dictionary<TKey, TValue> dictionary)
    {
        _dictionary = dictionary;
    }

    public SwitchMachine(params (TKey key, TValue value)[] pairs)
    {
        _dictionary = new Dictionary<TKey, TValue>();
        foreach (var (key, value) in pairs)
            _dictionary[key] = value;
    }

    public void SwitchTo(TKey key)
    {
        if (CurrentKey != null && CurrentKey.Equals(key))
            return;

        if (!_dictionary.TryGetValue(key, out var newSwitch))
            throw new KeyNotFoundException($"No switchable found for key '{key}'");

        CurrentValue?.Deactivate();

        newSwitch.Activate();

        CurrentValue = newSwitch;
        CurrentKey = key;
    }

    public void DeactivateCurrent()
    {
        CurrentValue?.Deactivate();

        CurrentValue = default;
        CurrentKey = default;
    }
}
