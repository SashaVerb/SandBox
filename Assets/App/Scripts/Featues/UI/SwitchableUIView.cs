using UnityEngine;

public class SwitchableUIView : MonoBehaviour, ISwitchable
{
    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
