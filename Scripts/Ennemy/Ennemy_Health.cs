﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy_Health : HealthComponent
{
    public static int nombreDeMort = 0;
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
        //ennemyMaster.CallEventEventEnnemyDeductHealth(healthLevel);

        if (IsDead())
        {
            nombreDeMort++;
            healthLevel = 0;
            ennemyMaster.CallEventEnnemyDie();
            Destroy(gameObject ,Random.Range(10,20));
            SpawnerV3.NombreSpawner--;
        }
    }
}
