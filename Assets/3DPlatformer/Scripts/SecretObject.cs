using System;
using UnityEngine;

public class SecretObject : MonoBehaviour, ITriggerObject
{
    [SerializeField] private bool isFind;

    public event Action FindSecretObject;

    public void ExitAction(Character character)
    {
    }

    public void TriggerAction(Character character)
    {
        if(character.GetComponent<Player>())
        {
            if(isFind == false)
            {
                isFind = true;
                FindSecretObject?.Invoke();
            }
            
        }
    }
}
