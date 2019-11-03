using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy_Health : HealthComponent
{
    private Ennemy_Master ennemyMaster;
    private void OnEnable()
    {
        SetInitialReferences();
        ennemyMaster.EventEnnemyDeductHealth += TakeDamage;
    }

    private void OnDisable()
    {
        ennemyMaster.EventEnnemyDeductHealth -= TakeDamage;
    }

    void SetInitialReferences()
    {
        ennemyMaster = GetComponent<Ennemy_Master>();
    }

    public override void TakeDamage(int healthPoint)
    {
        healthLevel -= healthPoint;

        if (IsDead())
        {
            healthLevel = 0;
            ennemyMaster.CallEventEnnemyDie();
            Destroy(gameObject/*, Random.Range(10,20)*/);
        }
    }
}
