using UnityEngine;

public class MVC_PrefabRotationView : MVC_RotationView
{
    private Transform _prefabTransform;

    public MVC_PrefabRotationView(GameObject prefab)
    {
        if(prefab)
            _prefabTransform = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity).transform;
    }

    public override void Clear()
    {
        Object.Destroy(_prefabTransform.gameObject);
    }

    public override void SetRotation(Quaternion rotation)
    {
        _prefabTransform.rotation = rotation;
    }
}
