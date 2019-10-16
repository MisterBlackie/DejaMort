using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemy_NavPause : MonoBehaviour
{
    private Ennemy_Master ennemyMaster;
    private NavMeshAgent myNavMeshAgent;
    private float pauseTime = 1;

    private void OnEnable()
    {
        SetInitialReferences();
        ennemyMaster.EventEnnemyDie += DisableThis;
        ennemyMaster.EventEnnemyDeductHealth += PauseNavMeshAgent;
    }

    private void OnDisable()
    {
        ennemyMaster.EventEnnemyDie -= DisableThis;
        ennemyMaster.EventEnnemyDeductHealth -= PauseNavMeshAgent;
    }

    void SetInitialReferences()
    {
        ennemyMaster = GetComponent<Ennemy_Master>();
        if (GetComponent<NavMeshAgent>() != null)
        {
            myNavMeshAgent = GetComponent<NavMeshAgent>();
        }
    }

    void PauseNavMeshAgent(int dummy)
    {
        if (myNavMeshAgent != null)
        {
            if (myNavMeshAgent.enabled)
            {
                myNavMeshAgent.ResetPath();
                ennemyMaster.isNavPaused = true;
                StartCoroutine(RestartNavMeshAgent());
            }
        }
    }

    IEnumerator RestartNavMeshAgent()
    {
        yield return new WaitForSeconds(pauseTime);
        ennemyMaster.isNavPaused = false;
    }
    void DisableThis()
    {
        StopAllCoroutines();
    }
}
