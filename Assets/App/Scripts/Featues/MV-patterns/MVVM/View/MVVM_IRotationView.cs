using UnityEngine;

public interface MVVM_IRotationView : ISubscribable
{
    void SetRotation(Quaternion rotation);
}
