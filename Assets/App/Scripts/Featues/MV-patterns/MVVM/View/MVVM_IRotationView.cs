using UnityEngine;

public interface MVVM_IRotationView : ISubscriable
{
    void SetRotation(Quaternion rotation);
}
