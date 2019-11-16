using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HotbarComponent : MonoBehaviour
{
    private List<GameObject> inventory;

    [SerializeField]
    private GameObject HotbarUIPrefab;

    private GameObject HotBarUI;
    private List<HotbarSpaceComponent> inventorySpaces = new List<HotbarSpaceComponent>();
    
    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<InventoryEventArgs> ItemUsed;
    public event EventHandler<InventoryEventArgs> ItemDestroyed;
    public event EventHandler<InventoryEventArgs> ItemDropped;

    void Awake()
    {
        HotBarUI = Instantiate(HotbarUIPrefab);
        GetItemCases();
        inventory = new List<GameObject>();
        for (int i = 0; i < inventorySpaces.Count; i++)
            inventory.Insert(i, null);
    }

    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            UseItem(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            UseItem(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            UseItem(2);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            UseItem(3);
        if (Input.GetKeyDown(KeyCode.Alpha5))
            UseItem(4);
    }

    private void GetItemCases()
    {
        var itemCases = HotBarUI.GetComponentsInChildren<HotbarSpaceComponent>();

        foreach (var itemCase in itemCases)
        {
            inventorySpaces.Add(itemCase);
        }

        inventorySpaces.OrderBy(i => i.ID);
    }

    public bool AddItem(GameObject itemObject)
    {
        bool itemAdded = false;

        if (itemObject != null)
        {
            IItem item = itemObject.GetComponent<IItem>();

            for (int i = 0; i < inventory.Count && !itemAdded; i++)
            {
                if (inventory[i] == null)
                {
                    inventory[i] = itemObject;
                    inventorySpaces[i].RefreshCase(item);
                    itemAdded = true;
                }
            }

            if (itemAdded)
            {
                item.OnPickup();
                ItemAdded?.Invoke(this, new InventoryEventArgs(item));
            }
            else
                throw new InventoryFullException();
        }

        return itemAdded;
    }

    public bool UseItem(int index)
    {
        Debug.Assert(index < inventorySpaces.Count);

        if (inventory[index] != null)
        {
            IItem item = inventory[index].GetComponent<IItem>();
            bool used = item.Use();
            if (used)
            {
                inventory[index] = null;
                inventorySpaces[index].HideImage();

                ItemUsed?.Invoke(this, new InventoryEventArgs(item));
                return true;
            }
            
        }

        return false;
    }
}