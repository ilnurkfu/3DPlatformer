using UnityEngine;

public class SpeedEffect : IEffect
{
    [SerializeField] private float scaleSpeed;
    [SerializeField] private float duration;

    public SpeedEffect(float newScaleSpeed, float newDuration)
    {
        scaleSpeed = newScaleSpeed;
        duration = newDuration;

    }

    public void Apply(Character character)
    {
        character.StartCoroutine(character.ChangeSpeed(scaleSpeed, duration));
    }

    public string GetDescription()
    {
        return $"���������� �������� � {scaleSpeed} ��� �� {duration} ������";
    }
}
