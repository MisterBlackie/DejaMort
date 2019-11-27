using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy_ColisionField : MonoBehaviour
{
    private Ennemy_Master ennemyMaster;
    private Rigidbody rigibodyStrikingMe;
    private int damageToApply;
    public float massRequirement = 50;
    //public float speedRequirement = 5;
    private float damageFactor = 0.1f;
    public int damageMultiplier = 1;
  

    private void OnEnable()
    {
        SetInitialReferences();
        ennemyMaster.EventEnnemyDie += DisableThis;
    }

    private void OnDisable()
    {
        ennemyMaster.EventEnnemyDie -= DisableThis;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            rigibodyStrikingMe = other.GetComponent<Rigidbody>();
       
            if (rigibodyStrikingMe.mass >= massRequirement && other.GetComponent<Rigidbody>().tag == "arme" )
            {
                //damageToApply = (int)(damageFactor * rigibodyStrikingMe.mass );
                ennemyMaster.CallEventEventEnnemyDeductHealth(other.GetComponent<IWeapon>().Damage);
                PlayerComponent.instance.equippedItem.EnleverCollider();
            }
        }
    }
    void SetInitialReferences()
    {
        //arme = GameObject.FindGameObjectWithTag("arme");
        ennemyMaster = transform.root.GetComponent<Ennemy_Master>();
    }
    void DisableThis()
    {
        gameObject.SetActive(false);
    }
}
