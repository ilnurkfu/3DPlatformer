using UnityEngine;

public class ChangeColorPotion : PotionBase
{
    [SerializeField] private Color color;
    public override IEffect GetEffect()
    {
        return new ChangeColorEffect(color);
    }

    public override void SetRandomValue()
    {
        color = new Color(Random.value, Random.value, Random.value);
    }
}
