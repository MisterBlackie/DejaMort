using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyDetection : MonoBehaviour
{
    private Ennemy_Master ennemyMaster;
    private Transform myTransform;
    public Transform head;
    public LayerMask playerLayer;
    public LayerMask sightLayer;
    private float checkRate;
    private float nextCheck;
    private float detectRadius = 80;
    private RaycastHit hit;


    private void OnEnable()
    {
        SetInitialRefernce();
        ennemyMaster.EventEnnemyDie += DisableThis;
    }
    private void OnDisable()
    {
        ennemyMaster.EventEnnemyDie -= DisableThis;
    }

    private void Update()
    {
        CarryOutDetection();
    }
    void SetInitialRefernce()
    {
        ennemyMaster = GetComponent<Ennemy_Master>();

        myTransform = transform;

        if (head == null)
        {
            head = myTransform;
        }
        checkRate = Random.Range(0.8f, 1.2f);
    }

    void CarryOutDetection()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;

            Collider[] colliders = Physics.OverlapSphere(myTransform.position, detectRadius, playerLayer);

            if (colliders.Length > 0)
            {
                foreach(Collider pottentialTargetCollider in colliders)
                {
                    if (pottentialTargetCollider.CompareTag(Game_Manager_Reference._playerTag))
                    {
                        if (CanPotentialTargetBeSeen(pottentialTargetCollider.transform))
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                ennemyMaster.CallEventEnnemyLostTarget();
            }
           
        }
    }

    bool CanPotentialTargetBeSeen(Transform potentialTarget)
    {
        if (Physics.Linecast(head.position , potentialTarget.position , out hit , sightLayer))
        {
            if (hit.transform == potentialTarget)
            {
                ennemyMaster.CallEventEnnemySetNavTarget(potentialTarget);
                return true;
            }
            else
            {
                ennemyMaster.CallEventEnnemyLostTarget();
                return false;
            }
        }
        else
        {
            ennemyMaster.CallEventEnnemyLostTarget();
            return false;
        }
    }

    void DisableThis()
    {
        this.enabled = false;
    }

}
