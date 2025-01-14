using UnityEngine;

public class Trap : MonoBehaviour, ITriggerObject
{
    [SerializeField] private bool isReady;

    [SerializeField] private int damage;

    [SerializeField] private float timer;

    [SerializeField] private string animationName;

    [SerializeField] private Animator anim;

    [SerializeField] private DamageType damageType;

    private void Update()
    {
        if (isReady == false)
        {
            timer -= Time.deltaTime;
            Debug.Log(anim.GetCurrentAnimatorStateInfo(0).speed);

            if (timer <= 0)
            {
                isReady = true;
            }
        }
    }

    public void ExitAction(Character character)
    {
    }

    public void TriggerAction(Character character)
    {
        if (isReady == true)
        {
            ActivatedTrap();
            character.ApplyDamage(damage, damageType);
            isReady = false;
        }
    }

    private void ActivatedTrap()
    {
        anim.Play(animationName);
        Debug.Log(anim.GetCurrentAnimatorStateInfo(0).speed);
        timer = anim.GetCurrentAnimatorStateInfo(0).length;
    }

    private float GetAnimationLenght()
    {
        RuntimeAnimatorController runtimeAnimatorController = anim.runtimeAnimatorController;

        for (int i = 0; i < runtimeAnimatorController.animationClips.Length; i++)
        {
            if (runtimeAnimatorController.animationClips[i].name == animationName)
            {
                return runtimeAnimatorController.animationClips[i].name.Length;
            }
        }

        return 0f;
    }
}
