using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy_Master : MonoBehaviour
{
    public Transform myTarget;

    public delegate void GeneralEventHandler();
    public event GeneralEventHandler EventEnnemyDie;
    public event GeneralEventHandler EventEnnemyWalking;
    public event GeneralEventHandler EventEnnemyReachNavTarget;
    public event GeneralEventHandler EventEnnemyAttack;
    public event GeneralEventHandler EventEnnemyLostTarget;

    public delegate void HealthEventHandler(int health);
    public event HealthEventHandler EventEnnemyDeductHealth;

    public delegate void NavTargetEventHandler(Transform TargetTransform);
    public event NavTargetEventHandler EventEnnemySetNavTarget;
    public bool isOnRoute;
    public bool isNavPaused;

    public void CallEventEventEnnemyDeductHealth(int health)
    {
        if (EventEnnemyDeductHealth != null)
        {
            EventEnnemyDeductHealth(health);
        }
    }

    public void CallEventEnnemySetNavTarget(Transform TargTransform)
    {
        if (EventEnnemySetNavTarget != null)
        {
            EventEnnemySetNavTarget(TargTransform);
        }
        myTarget = TargTransform;

    }

    public void CallEventEnnemyDie()
    {
        if (EventEnnemyDie != null)
        {
            EventEnnemyDie();
        }
    }

    public void CallEventEnnemyWalking()
    {
        if (EventEnnemyWalking != null)
        {
            EventEnnemyWalking();
        }
    }

    public void CallEventEnnemyReachNavTarget()
    {
        if (EventEnnemyReachNavTarget != null)
        {
            EventEnnemyReachNavTarget();
        }
    }

    public void CallEventEnnemyAttack()
    {
        if (EventEnnemyAttack != null)
        {
            EventEnnemyAttack();
        }
    }

    public void CallEventEnnemyLostTarget()
    {
        if (EventEnnemyLostTarget != null)
        {
            EventEnnemyLostTarget();
        }

        myTarget = null;
    }


}
