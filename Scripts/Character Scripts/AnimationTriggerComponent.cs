using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationTriggerComponent : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    Animator rightHandAnimator;
    [SerializeField]
    Animator leftHandAnimator;

    bool isIdle = true;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        HealthComponent health = GetComponent<HealthComponent>();
        AttackComponent attackComp = GetComponent<AttackComponent>();
        ItemPickUpComponent pickup = GetComponent<ItemPickUpComponent>();

        if (health != null)
            health.OnDeath += (s, a) => animator.SetTrigger("DeathTrigger");
        if (attackComp != null)
            attackComp.OnPrimaryAttack += (a, s) => rightHandAnimator.SetTrigger("MeleeAttackTrigger");
        if (pickup != null)
            pickup.OnPickup += (a, s) => rightHandAnimator.SetTrigger("GrabTrigger");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 && isIdle)
        {
            animator.SetTrigger("RunningTrigger");
        }
        else
        {
            animator.ResetTrigger("RunningTrigger");
            animator.SetTrigger("IdleTrigger");
        }
    }
}
