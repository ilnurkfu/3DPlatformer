using UnityEngine;

public interface IEffect
{
    public string GetDescription();
    public void Apply(Character character);
}
