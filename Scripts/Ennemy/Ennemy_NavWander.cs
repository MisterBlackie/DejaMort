using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemy_NavWander : MonoBehaviour
{
    private Ennemy_Master ennemyMaster;
    private NavMeshAgent myNavMeshAgent;
    private float checkRate;
    private float nextCheck;
    private float wanderRange = 10;
    private Transform myTransform;
    private NavMeshHit navHit;
    private Vector3 wanderTarget;

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
            checkIfShouldWander();
        }
    }
    void SetInitialReference()
    {
        ennemyMaster = GetComponent<Ennemy_Master>();
        if (GetComponent<NavMeshAgent>() != null)
        {
            myNavMeshAgent = GetComponent<NavMeshAgent>();
        }
        checkRate = Random.Range(0.3f, 0.4f);
        myTransform = transform;
    }

    void checkIfShouldWander()
    {
        if (ennemyMaster.myTarget == null && !ennemyMaster.isOnRoute && !ennemyMaster.isNavPaused)
        {
            if (RandomWanderTarget(myTransform.position , wanderRange , out wanderTarget))
            {
                myNavMeshAgent.SetDestination(wanderTarget);
                ennemyMaster.isOnRoute = true;
                ennemyMaster.CallEventEnnemyWalking();
            }
        }
    }

    bool RandomWanderTarget(Vector3 centre, float range, out Vector3 result)
    {
        Vector3 randomPoint = centre + Random.insideUnitSphere * wanderRange;
        if (NavMesh.SamplePosition(randomPoint , out navHit , 1.0f , NavMesh.AllAreas))
        {
            result = navHit.position;
            return true;
        }
        else
        {
            result = centre;
            return  false;
        }
    }

    void DisableThis()
    {
        this.enabled = false;
    }
}
