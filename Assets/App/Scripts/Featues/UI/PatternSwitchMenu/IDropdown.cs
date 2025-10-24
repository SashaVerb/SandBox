using System;
using System.Collections.Generic;

public interface IDropdown : ISwitchable
{
    string CurrentOption { get; }
    void SetOptions(List<string> options);

    event Action<string> OnChooseOption;
}
