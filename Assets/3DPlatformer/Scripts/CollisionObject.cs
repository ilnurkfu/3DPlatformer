using UnityEngine;

public class CollisionObject : MonoBehaviour
{
    [SerializeField] private float bonusSpeed;

    public float BonusSpeed
    {
        get
        {
            return bonusSpeed;
        }
    }
}
