using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationTriggerComponent : MonoBehaviour
{
    Animator animator;
    bool isIdle = true;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        HealthComponent health = GetComponent<HealthComponent>();
        if (health != null) ;
            //health.OnDeath += (s, a) => animator.SetTrigger("DeathTrigger");
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
