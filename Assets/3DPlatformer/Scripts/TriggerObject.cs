using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    [SerializeField] private bool isActive = true;

    public bool IsActive
    {
        get 
        {
            return isActive; 
        }
    }

    public void Deactivated()
    {
        isActive = false;
    }

    public void Activated()
    {
        isActive = true;
    }
}
