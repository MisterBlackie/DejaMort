using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy_Health : MonoBehaviour
{
    private Ennemy_Master ennemyMaster;
    public int ennemyhealth = 100;
    private void OnEnable()
    {
        SetInitialReferences();
        ennemyMaster.EventEnnemyDeductHealth += DeductHealth;
    }

    private void OnDisable()
    {
        ennemyMaster.EventEnnemyDeductHealth -= DeductHealth;
    }

    void SetInitialReferences()
    {
        ennemyMaster = GetComponent<Ennemy_Master>();
    }

    void DeductHealth(int healthChange)
    {
        ennemyhealth -= healthChange;
        if (ennemyhealth <= 0)
        {
            ennemyhealth = 0;
            ennemyMaster.CallEventEnnemyDie();
            Destroy(gameObject , Random.Range(10,20));
        }
    }
}
