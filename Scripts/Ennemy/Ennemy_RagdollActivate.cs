using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy_RagdollActivate : MonoBehaviour
{
    private Ennemy_Master ennemyMaster;
    private Collider myCollider;
    private Rigidbody myRigidBody;

    private void OnEnable()
    {
        SetInitialReferences();
        ennemyMaster.EventEnnemyDie += ActivateRagDoll;
    }

    private void OnDisable()
    {
        ennemyMaster.EventEnnemyDie -= ActivateRagDoll;
    }

    void SetInitialReferences()
    {
        ennemyMaster = transform.root.GetComponent<Ennemy_Master>();
        if (GetComponent<Collider>() != null)
        {
            myCollider = GetComponent<Collider>();
        }
        if (GetComponent<Rigidbody>())
        {
            myRigidBody = GetComponent<Rigidbody>();
        }
    }

    void ActivateRagDoll()
    {
        if (myRigidBody != null)
        {
            myRigidBody.isKinematic = false;
            myRigidBody.useGravity = true;
        }
        if (myCollider != null)
        {
            myCollider.isTrigger = false;
            myCollider.enabled = true;
        }
    }
}
