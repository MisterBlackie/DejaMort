using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemy_NavPoursuite : MonoBehaviour
{
    private Ennemy_Master ennemyMaster;
    private NavMeshAgent myNavMeshAgent;
    private float checkRate;
    private float nextCheck;

    private void OnEnable()
    {
        SetInitialReference();
        ennemyMaster.EventEnnemyDie += DisableThis;
    }

    private void OnDisable()
    {
        ennemyMaster.EventEnnemyDie -= DisableThis;
    }

    private void Update()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            TrytoChaseTarget();
        }
    }

    void SetInitialReference()
    {
        ennemyMaster = GetComponent<Ennemy_Master>();
        if (GetComponent<NavMeshAgent>() != null)
        {
            myNavMeshAgent = GetComponent<NavMeshAgent>();
        }
        checkRate = Random.Range(0.1f, 0.2f);
    }

    void TrytoChaseTarget()
    {
        if (ennemyMaster.myTarget != null  && myNavMeshAgent != null && !ennemyMaster.isNavPaused)
        {
            myNavMeshAgent.SetDestination(ennemyMaster.myTarget.position);

            if (myNavMeshAgent.remainingDistance > myNavMeshAgent.stoppingDistance)
            {
                ennemyMaster.CallEventEnnemyWalking();
                ennemyMaster.isOnRoute = true;
            }
        }
    }

    void DisableThis()
    {
        if (myNavMeshAgent != null)
        {
            myNavMeshAgent.enabled = false;
        }

        this.enabled = false;
    }
}
