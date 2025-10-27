using UnityEngine;

public class SwitchableUIView : MonoBehaviour, ISwitchable
{
    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
