using System;
using UnityEngine;

public class MVC_PrefabRotationView : MVC_RotationView
{
    private Transform _prefabTransform;

    public MVC_PrefabRotationView(GameObject prefab)
    {
        if (prefab)
            _prefabTransform = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity).transform;
        else
            throw new ArgumentNullException($"Prefab is not assigned in {nameof(MVC_PrefabRotationView)}");
    }

    public override void Clear()
    {
        GameObject.Destroy(_prefabTransform.gameObject);
    }

    public override void SetRotation(Quaternion rotation)
    {
        _prefabTransform.rotation = rotation;
    }
}
