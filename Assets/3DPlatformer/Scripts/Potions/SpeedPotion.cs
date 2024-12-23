using UnityEngine;

public class SpeedPotion : PotionBase
{
    [SerializeField] private float scaleSpeed;
    [SerializeField] private float duration;

    public override IEffect GetEffect()
    {
        return new SpeedEffect(scaleSpeed, duration);
    }

    public override void SetRandomValue()
    {
    }
}
