using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{

    private List<IItem> inventory;

    void Awake()
    {
        inventory = new List<IItem>();
    }

    public bool AddItem(IItem item) {
        bool itemAdded = false;

        if (item != null)
        {
            inventory.Add(item);
            itemAdded = true;
            
        }

        return itemAdded;
    }

    public void UseItem(int index)
    {
        if (index < inventory.Count && index >= 0)
        {
            inventory[index].Use();
            inventory.RemoveAt(index);
        }
    }
}
