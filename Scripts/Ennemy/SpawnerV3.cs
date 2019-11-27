using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerV3 : MonoBehaviour
{
    public static int NombreSpawner = 0;
    public GameObject FirstObjectToSpawn;
    public GameObject SecondObjectToSpawn;
    public GameObject ThirdObjectToSpawn;
    public int NumberToSpawn;
    public float proximity;
    private float checkrate;
    public float delaiSpawn = 30; 
    private Transform myTransform;
    private Transform playerTransform;
    private Vector3 spawnPosition;
    private float spawnNiveau1Delai = 180;
    private float spawnNiveau2Delai = 360;
    const int MAX = 50;
    //private int Compteur = 0;
    //const int Max = 30;

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

        if (NombreSpawner < MAX)
        {

     
        if (Time.time > delaiSpawn && delaiSpawn < spawnNiveau1Delai)
        {
            //delaiSpawn = Time.time + checkrate;
            if (Vector3.Distance(myTransform.position, playerTransform.position) > proximity )
            {
                SpawnObject();
                delaiSpawn += delaiSpawn;
                NombreSpawner++;
                //this.enabled = false;
                //Compteur++;
            }
        }
        else if(Time.time > spawnNiveau1Delai && spawnNiveau1Delai < spawnNiveau2Delai)
        {
            if (Vector3.Distance(myTransform.position, playerTransform.position) > proximity)
            {
                SpawnObject2();
                spawnNiveau1Delai += delaiSpawn;
                NombreSpawner++;
            }
        }
        else if (Time.time > spawnNiveau2Delai)
        {
            if (Vector3.Distance(myTransform.position, playerTransform.position) > proximity)
            {
                SpawnObject3();
                spawnNiveau2Delai += delaiSpawn;
                NombreSpawner++;
            }
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
            Instantiate(SecondObjectToSpawn, newSpawnPos, transform.rotation);

        }
    }

    void SpawnObject3()
    {
        for (int i = 0; i < NumberToSpawn; i++)
        {
            spawnPosition = myTransform.position + Random.insideUnitSphere * 5;

            //  Instantiate(objectToSpawn, spawnPosition, myTransform.rotation);
            Vector3 newSpawnPos = new Vector3(spawnPosition.x, 0.5f, spawnPosition.z);
            Instantiate(ThirdObjectToSpawn, newSpawnPos, transform.rotation);

        }
    }
}
