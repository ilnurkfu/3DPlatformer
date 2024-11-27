using UnityEngine;

public abstract class PotionBase : MonoBehaviour, IPotionBase, ITriggerObject
{
    public abstract IEffect GetEffect();

    public void PickUp()
    {
        Destroy(gameObject);
    }

    public virtual void TriggerAction(Player player)
    {
        GetEffect().Apply(player);
        PickUp();
    }

    public abstract void SetRandomValue();
}
