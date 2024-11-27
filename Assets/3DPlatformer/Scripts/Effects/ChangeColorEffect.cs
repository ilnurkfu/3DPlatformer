using UnityEngine;

public class ChangeColorEffect : IEffect
{
    [SerializeField] private Color color;

    public ChangeColorEffect(Color newColor)
    {
        color = newColor;
    }

    public void Apply(Character character)
    {
        character.ChangeColor(color);
    }

    public string GetDescription()
    {
        return $"Изменение цвета на {color}";
    }
}
