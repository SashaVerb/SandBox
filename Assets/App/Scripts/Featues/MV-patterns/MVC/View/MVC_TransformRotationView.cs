using UnityEngine;

public class MVC_TransformRotationView : MVC_IRotationView
{
    readonly Transform _transform;

    public MVC_TransformRotationView(Transform transform)
    {
        _transform = transform;
    }

    public void SetRotation(Quaternion rotation)
    {
        _transform.rotation = rotation;
    }
}
