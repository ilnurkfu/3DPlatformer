using UnityEngine;

public class Lava : MonoBehaviour, ITriggerObject
{
    [SerializeField] private int damage;
    [SerializeField] private DamageType damageType;

    public void ExitAction(Character character)
    {
    }

    public void TriggerAction(Character character)
    {
        character.ApplyDamage(damage, damageType);
    }
}
