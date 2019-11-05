using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy_TakeDamage : MonoBehaviour
{
    private Ennemy_Master Ennemy_Master;
    public int damageMultiplier = 1;
    public bool shouldRemoveCollider;

    private void OnEnable()
    {
        SetInitialReferences();
        Ennemy_Master.EventEnnemyDie += RemoveThis;
    }

    private void OnDisable()
    {
        Ennemy_Master.EventEnnemyDie -= RemoveThis;
    }

    void SetInitialReferences()
    {
        Ennemy_Master = transform.root.GetComponent<Ennemy_Master>();
    }

    public void ProcessDamage(int damage)
    {
        int damageToapply = damage * damageMultiplier;
        Ennemy_Master.CallEventEventEnnemyDeductHealth(damageToapply);
    }

    public void RemoveThis()
    {
        if (shouldRemoveCollider)
        {
            if (GetComponent<Collider>() != null)
            {
                Destroy(GetComponent<Collider>());
            }
            if (GetComponent<Rigidbody>() != null)
            {
                Destroy(GetComponent<Rigidbody>() );
            }
        }
    }
}
