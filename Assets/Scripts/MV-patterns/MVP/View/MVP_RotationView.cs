using UnityEngine;

public abstract class MVP_RotationView
{
    protected MVP_RotationPresenter _presenter;

    protected MVP_RotationView(MVP_RotationPresenter presenter)
    {
        _presenter = presenter;
    }

    public abstract void SetRotation(Quaternion rotation);

    public abstract void Clear();
}
