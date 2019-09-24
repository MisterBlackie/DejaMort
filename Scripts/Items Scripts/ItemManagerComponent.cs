using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManagerComponent : MonoBehaviour
{
    Object[] itemsList;
    ItemSpawnerComponent[] spawners;
    public float timeBetweenEachItemSpawn = 300;
    float timeBeforeSpawning;

    private void Start()
    {
        spawners = FindObjectsOfType<ItemSpawnerComponent>();
        itemsList = Resources.LoadAll("Items");
        timeBeforeSpawning = timeBetweenEachItemSpawn;
    }

    private void Update()
    {
        timeBeforeSpawning -= Time.deltaTime;
        if (timeBeforeSpawning <= 0)
        {
            instantiateItems();
            timeBeforeSpawning = timeBetweenEachItemSpawn;
        }
        
    }
    public void instantiateItems() {
        foreach (var spawner in spawners) {
            spawner.instantiateItem((GameObject)itemsList[Random.Range(0, itemsList.Length)]);
        }
    }
}
