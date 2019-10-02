using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerV3 : MonoBehaviour
{
    public GameObject objectToSpawn;
    public int NumberToSpawn;
    public float proximity;
    private float checkrate;
    private float nextCheck;
    private Transform myTransform;
    private Transform playerTransform;
    private Vector3 spawnPosition;

    private void Start()
    {
        SetInitiateReference();
    }
    private void Update()
    {
        CheckDistance();
    }

    void SetInitiateReference()
    {
        myTransform = transform;
        playerTransform = Game_Manager_Reference.player.transform;
        checkrate = Random.Range(0.8f, 1.2f);
    }

    void CheckDistance()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkrate;
            if (Vector3.Distance(myTransform.position, playerTransform.position) < proximity)
            {
                SpawnObject();
                this.enabled = false;
            }
        }
    }

    void SpawnObject()
    {
        for (int i = 0; i < NumberToSpawn; i++)
        {
            spawnPosition = myTransform.position + Random.insideUnitSphere;

            Instantiate(objectToSpawn, spawnPosition, myTransform.rotation);
            Vector3 newSpawnPos = new Vector3(spawnPosition.x, 0.5f, spawnPosition.z); Instantiate(objectToSpawn, newSpawnPos, transform.rotation);
          
        }
    }
}
