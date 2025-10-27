using UnityEngine;

public interface MVC_IRotationController : ISubscribable
{
    void Rotate(Vector3 axis);
    void SetRotation(Quaternion rotation);
}
