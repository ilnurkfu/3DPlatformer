using System;
using UnityEngine;

public class Finish : MonoBehaviour, ITriggerObject
{
    public event Action OnFinished;
    public void ExitAction(Character character)
    {
        
    }

    public void TriggerAction(Character character)
    {
        if(character.GetComponent<Player>())
        {
            OnFinished?.Invoke();
        }
    }
}
