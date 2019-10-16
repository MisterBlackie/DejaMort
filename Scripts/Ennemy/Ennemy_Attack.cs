using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemy_Attack : MonoBehaviour
{
    private Ennemy_Master ennemyMaster;
    private Transform attackTarget;
    private Transform myTransform;
    public float attackRate = 1;
    private float nextAttack;
    public float attackRamge = 3.5f;
    public int attackDamge = 10;


    private void OnEnable()
    {
        SetInitialReferences();
        ennemyMaster.EventEnnemyDie += DisableThis;
        ennemyMaster.EventEnnemySetNavTarget += SetAttackTarget;
    }

    private void OnDisable()
    {
        ennemyMaster.EventEnnemyDie -= DisableThis;
        ennemyMaster.EventEnnemySetNavTarget -= SetAttackTarget;
    }
    private void Update()
    {
        TryToAttack();
    }
    void SetInitialReferences()
    {
        ennemyMaster = GetComponent<Ennemy_Master>();
        myTransform = transform;

    }
    void SetAttackTarget(Transform targetTransform)
    {
        attackTarget = targetTransform;
    }

    void TryToAttack()
    {
        if (attackTarget != null)
        {
            if (Time.time > nextAttack)
            {
                nextAttack = Time.time + attackRate;
                if (Vector3.Distance(myTransform.position , attackTarget.position) <= attackRamge)
                {
                    Vector3 lookAtVector = new Vector3(attackTarget.position.x, myTransform.position.y, attackTarget.position.z);
                    myTransform.LookAt(lookAtVector);
                    ennemyMaster.CallEventEnnemyAttack();
                    ennemyMaster.isOnRoute = false;
                }
            }
        }
    }

    public void OnEnnemyAttack()
    {
        if (attackTarget != null)
        {
            if (Vector3.Distance(myTransform.position , attackTarget.position) <= attackRamge &&
                attackTarget.GetComponent<PlayerManager>() != null)
            {
                Vector3 toOther = attackTarget.position - myTransform.position;
                if (Vector3.Dot(toOther , myTransform.forward) > 0.5f)
                {
                    //attackTarget.GetComponent<PlayerManager>
                }
            }
        }
        
    }

    void DisableThis()
    {
        this.enabled = false;
    }

}
