using UnityEngine;

public class ResizeEffect : IEffect
{
    [SerializeField] private float scaleMultiplier;
    public ResizeEffect(float multiplier)
    {
        scaleMultiplier = multiplier;
    }

    public void Apply(Character character)
    {
        character.Resize(scaleMultiplier);
    }

    public string GetDescription()
    {
        return $"Увеличение размера в {scaleMultiplier} раз";
    }
}
