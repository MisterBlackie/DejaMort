using UnityEngine;
using UnityEngine.AI;

public class Ennemy_NavDestinationReached : MonoBehaviour
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
            CheckIfDestinationReached();
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
    }

    void CheckIfDestinationReached()
    {
        if (ennemyMaster.isOnRoute)
        {
            if (myNavMeshAgent.remainingDistance < myNavMeshAgent.stoppingDistance)
            {
                ennemyMaster.isOnRoute = false;
               
             

                ennemyMaster.CallEventEnnemyReachNavTarget();
            }
        }
    }

    void DisableThis()
    {
        this.enabled = false;
    }
}
