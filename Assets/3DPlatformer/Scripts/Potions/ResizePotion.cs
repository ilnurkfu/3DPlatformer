using UnityEngine;

public class ResizePotion : PotionBase
{
    [SerializeField] private float scaleMultiplier;

    public override IEffect GetEffect()
    {
        return new ResizeEffect(scaleMultiplier);
    }

    public override void SetRandomValue()
    {
        scaleMultiplier = Random.Range(0.5f, 2f);
    }
}
