using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemManagerComponent : MonoBehaviour
{
    public GameObject[] itemsPrefabList { get; private set; }
    IItem[] items;

    ItemSpawnerComponent[] spawners;

    [SerializeField]
    float timeBetweenEachItemSpawn = 300;
    float timeBeforeSpawning;

    private void Start()
    {
        spawners = FindObjectsOfType<ItemSpawnerComponent>();
        itemsPrefabList = Resources.LoadAll<GameObject>("Items");
        items = new IItem[itemsPrefabList.Length];
        for (int i = 0; i < itemsPrefabList.Length; i++)
        {
            items[i] = itemsPrefabList[i].GetComponent<IItem>();
        }

        timeBeforeSpawning = timeBetweenEachItemSpawn;

        instantiateItems();
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
            spawner.instantiateItem(itemsPrefabList[Random.Range(0, itemsPrefabList.Length)]);
        }
    }


    // Retourn le prefab relié à un certain item, ou null si cet item n'as pas de prefab
    public GameObject GetPrefabOfItem(string itemUniqueCode)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].itemUniqueCode == itemUniqueCode)
            {
                return itemsPrefabList[i];
            }
        }

        return null;
    }
}
