using UnityEngine;

public abstract class PotionBase : MonoBehaviour, IPotionBase, ITriggerObject
{
    public abstract IEffect GetEffect();

    public void PickUp()
    {
        Destroy(gameObject);
    }

    public virtual void TriggerAction(Character character)
    {
        GetEffect().Apply(character);
        PickUp();
    }

    public abstract void SetRandomValue();

    public void ExitAction(Character character)
    {
    }
}
