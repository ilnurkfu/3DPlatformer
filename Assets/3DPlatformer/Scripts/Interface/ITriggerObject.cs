using System;
using UnityEngine;

public interface ITriggerObject
{
    public void TriggerAction(Character character);

    public void ExitAction(Character character);
}
