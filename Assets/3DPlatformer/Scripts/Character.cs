using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public virtual void Resize(float newMultiplaer)
    {
        transform.localScale = Vector3.one * newMultiplaer;
    }

    public void ChangeColor(Color newColor)
    {
        GetComponent<MeshRenderer>().material.color = newColor;
    }

    protected void ApplyEffect(IEffect effect)
    {
        Debug.Log($"Полуен эффект: {effect.GetDescription()}");
        effect.Apply(this);
    }
}
