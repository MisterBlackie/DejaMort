using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    private List<IItem> inventory;

    [SerializeField]
    private GameObject inventoryUIPrefab;

    [SerializeField]
    private KeyCode inventoryKey = KeyCode.I;

    private GameObject inventoryUI;
    private List<ItemCaseComponent> inventorySpaces = new List<ItemCaseComponent>();
    private CharacterMovingComponentv2 characterMovingComp;
    void Awake()
    {
        characterMovingComp = GetComponent<CharacterMovingComponentv2>();

        inventory = new List<IItem>();
        inventoryUI = Instantiate(inventoryUIPrefab);
        inventoryUI.SetActive(false); // Honnêtement, je devrais pas à faire ça ici, à changer
        GetItemCases();
    }

    void Update()
    {
        if (Input.GetKeyDown(inventoryKey))
            toggleInventoryUI();
    }

    private void GetItemCases() {
        var itemCases = inventoryUI.GetComponentsInChildren<ItemCaseComponent>();

        int Compteur = 0;
        foreach (ItemCaseComponent itemCase in itemCases)
        {
            itemCase.ID = Compteur;
            itemCase.inventory = this;

            inventorySpaces.Add(itemCase);
            Compteur++;
        }
    }

    public bool AddItem(IItem item) {
        bool itemAdded = false;

        // En ce moment, la maximum d'espace d'inventaire est le nombre de case dans l'UI
        if (inventory.Count >= inventorySpaces.Count)
            throw new InventoryFullException();

        if (item != null)
        {
            inventory.Add(item);
            itemAdded = true;
            
        }

        return itemAdded;
    }

    public bool UseItem(int index)
    {
        if (index < inventory.Count && index >= 0)
        {
            inventory[index].Use();
            inventory.RemoveAt(index);
            return true;
        }

        return false;
    }

    private void toggleInventoryUI() {
        bool active = inventoryUI.activeSelf;

        if (!active)
        {
            characterMovingComp.UnlockMouse();
            showInventoryOnUI();
        }
        else {
            characterMovingComp.LockMouse();
        }

        inventoryUI.SetActive(!active);
    }

    private void showInventoryOnUI() {
        for (int i = 0; i < inventory.Count; i++) {
            inventorySpaces[i].setItem(inventory[i]);
            inventorySpaces[i].showImage();
        }

    }
}


public class InventoryFullException : Exception {
    // TODO
}