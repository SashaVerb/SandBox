using System;

public interface IPatternMenuView : IRotationMenu, ISwitchable
{
    event Action OnGoBack;
}
