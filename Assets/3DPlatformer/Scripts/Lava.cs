using UnityEngine;

public class Lava : MonoBehaviour, ITriggerObject
{
    [SerializeField] private int damage;

    public void TriggerAction(Player player)
    {
        player.ApplyDamage(damage);
    }
}
