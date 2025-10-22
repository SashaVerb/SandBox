using UnityEngine;

public class MVVM_FreeRotationViewModel : MVVM_RotationViewModel
{
    public MVVM_FreeRotationViewModel(MVVM_RotationModel model) : base(model)
    {

    }

    public override void Rotate(Vector3 axis)
    {
        _model.Rotate(axis);
    }

    public override void SetRotation(Quaternion rotation)
    {
        _model.SetRotation(rotation);
    }
}
