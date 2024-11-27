using UnityEngine;

public interface IPotionBase
{
    public IEffect GetEffect();
    public void PickUp();

    public void SetRandomValue();
}
