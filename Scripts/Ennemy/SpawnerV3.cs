using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerV3 : MonoBehaviour
{
    public GameObject FirstObjectToSpawn;
    public GameObject SecondObjectToSpawn;
    public int NumberToSpawn;
    public float proximity;
    private float checkrate;
    public float delaiSpawn = 100; 
    private Transform myTransform;
    private Transform playerTransform;
    private Vector3 spawnPosition;
    private int Compteur = 0;
    const int Max = 30;

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
        if (Time.time > delaiSpawn)
        {
            delaiSpawn = Time.time + checkrate;
            if (Vector3.Distance(myTransform.position, playerTransform.position) > proximity && Compteur < Max)
            {
                SpawnObject();
                delaiSpawn *= 2;
                //this.enabled = false;
                Compteur++;
            }
        }
        else if(Time.time > delaiSpawn * 10)
        {
            if (Vector3.Distance(myTransform.position, playerTransform.position) > proximity && Compteur < Max)
            {
                SpawnObject2();
                delaiSpawn *= 2;
                //this.enabled = false;
                Compteur++;
            }
        }
    }

    void SpawnObject()
    {
        for (int i = 0; i < NumberToSpawn; i++)
        {
            spawnPosition = myTransform.position + Random.insideUnitSphere * 5;

          //  Instantiate(objectToSpawn, spawnPosition, myTransform.rotation);
           Vector3 newSpawnPos = new Vector3(spawnPosition.x, 0.5f, spawnPosition.z); 
            Instantiate(FirstObjectToSpawn, newSpawnPos, transform.rotation);
          
        }
    }

    void SpawnObject2()
    {
        for (int i = 0; i < NumberToSpawn; i++)
        {
            spawnPosition = myTransform.position + Random.insideUnitSphere * 5;

            //  Instantiate(objectToSpawn, spawnPosition, myTransform.rotation);
            Vector3 newSpawnPos = new Vector3(spawnPosition.x, 0.5f, spawnPosition.z);
            Instantiate(FirstObjectToSpawn, newSpawnPos, transform.rotation);

        }
    }
}
