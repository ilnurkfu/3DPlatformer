using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float speed;

    public event Action OnDied;

    [SerializeField] private DamageType[] resistance;

    public virtual void Resize(float newMultiplaer)
    {
        transform.localScale = Vector3.one * newMultiplaer;
    }

    public void ChangeColor(Color newColor)
    {
        GetComponent<MeshRenderer>().material.color = newColor;
    }

    public void ApplyDamage(int newDamage, DamageType damageType)
    {
        Debug.Log(resistance.Contains(damageType));
        if(resistance.Contains(damageType))
        {
            Debug.Log($"У персонажа {name} иммунитет к типу урона {damageType.ToString()}");
            return;
        }
        health = Mathf.Max(0, health - newDamage);
        if (health == 0)
        {
            Died();
        }
    }

    public IEnumerator ChangeSpeed(float scaleSpeed, float duration)
    {
        speed *= scaleSpeed;
        Debug.Log("ChangeSpeed");

        while (duration > 0)
        {
            duration -= Time.deltaTime;
            Debug.Log("Current duration:= " + duration);
            yield return null;
        }

        speed /= scaleSpeed;
    }

    protected virtual void Died()
    {
        Debug.Log("Потрачено");
        OnDied?.Invoke();
    }

    protected void ApplyEffect(IEffect effect)
    {
        Debug.Log($"Полуен эффект: {effect.GetDescription()}");
        effect.Apply(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ITriggerObject>() != null)
        {
            other.GetComponent<ITriggerObject>().TriggerAction(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ITriggerObject>() != null)
        {
            other.GetComponent<ITriggerObject>().ExitAction(this);
        }
    }



}

public enum DamageType
{
    Physical,
    Fire
}