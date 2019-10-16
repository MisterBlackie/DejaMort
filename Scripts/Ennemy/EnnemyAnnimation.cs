using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyAnnimation : MonoBehaviour
{
    private Ennemy_Master ennemyMaster;
    private Animator myAnimator;




    private void OnEnable()
    {
        SetInitialReference();
       ennemyMaster.EventEnnemyDie += DisableAnimator;
        ennemyMaster.EventEnnemyWalking += SetAnimationToWalk;
        ennemyMaster.EventEnnemyReachNavTarget += SetAnimationToIdle;
        ennemyMaster.EventEnnemyAttack += SetAnimationToAttack;
        ennemyMaster.EventEnnemyDeductHealth += SetAnimationToStruck;
    }
    private void OnDisable()
    {
        ennemyMaster.EventEnnemyDie -= DisableAnimator;
        ennemyMaster.EventEnnemyWalking -= SetAnimationToWalk;
        ennemyMaster.EventEnnemyReachNavTarget -= SetAnimationToIdle;
        ennemyMaster.EventEnnemyAttack -= SetAnimationToAttack;
        ennemyMaster.EventEnnemyDeductHealth -= SetAnimationToStruck;
    }

    void SetInitialReference()
    {
        ennemyMaster = GetComponent<Ennemy_Master>();
        if (GetComponentInChildren<Animator>() != null)
        {
            myAnimator = GetComponentInChildren<Animator>();
        }
    }


    void SetAnimationToWalk()
    {
        if (myAnimator != null)
        {
            if (myAnimator.enabled)
            {
                myAnimator.SetBool("isPursuing", true);
            }
        }
    }

    void SetAnimationToIdle()
    {
        if (myAnimator != null)
        {
            if (myAnimator.enabled)
            {
                myAnimator.SetBool("isPursuing", false);
            }
        }
    }

    void SetAnimationToAttack()
    {
        if (myAnimator != null)
        {
            if (myAnimator.enabled)
            {
                myAnimator.SetTrigger("attack");
            }
        }
    }

    void SetAnimationToStruck(int dummy)
    {
        if (myAnimator != null)
        {
            if (myAnimator.enabled)
            {
                myAnimator.SetTrigger("struck");
            }
        }
    }

    void DisableAnimator()
    {
        if (myAnimator != null)
        {
            myAnimator.enabled = false;
        }
    }

}
