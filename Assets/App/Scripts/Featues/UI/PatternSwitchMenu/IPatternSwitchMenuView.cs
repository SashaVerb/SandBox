using System;
using System.Collections.Generic;

public interface IPatternSwitchMenuView
{
    event Action<string> OnChoosePattern;

    void SetOptions(List<string> options);
}
