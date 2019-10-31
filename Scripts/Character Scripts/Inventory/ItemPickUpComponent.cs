using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HotbarComponent))]
public class ItemPickUpComponent : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Caméra du joueur")]
    private Camera playerCamera;

    [SerializeField]
    [Tooltip("Panneau affichant les infos de l'item")]
    private GameObject itemPickUpPanel;

    public event EventHandler<ItemPickedArgs> OnPickup;

    private HotbarComponent inventory;
    private GameObject itemBeingPickUp;

    public void Awake()
    {
        inventory = GetComponent<HotbarComponent>();
        itemPickUpPanel.SetActive(false);
    }

    private void Update()
    {
        if (checkRayForItem()) {
            itemPickUpPanel.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E)) {
                Take();
            }
        }
    }

    private bool checkRayForItem() {
        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        bool itemIsValid = false;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {

                GameObject item = hit.collider.gameObject;

                if (item.GetComponent<IItem>() != null)
                {
                    if (itemBeingPickUp != item)
                    {
                        itemBeingPickUp = item;
                    }

                    itemIsValid = true;
                }
                else
                {
                    itemBeingPickUp = null;
                    itemPickUpPanel.SetActive(false);
                }
            }
        }
        else {
            itemBeingPickUp = null;
            itemPickUpPanel.SetActive(false);
        }

        return itemIsValid;
    }

    private void Take() {
        Debug.Assert(itemBeingPickUp != null);

        if (inventory.AddItem(itemBeingPickUp)) {
           
            itemPickUpPanel.SetActive(false);
            OnPickup?.Invoke(this, new ItemPickedArgs(itemBeingPickUp.GetComponent<IItem>()));
            itemBeingPickUp = null;
        }
    }
}

public class ItemPickedArgs {
    IItem Item;

    public ItemPickedArgs(IItem item ) {
        Item = item;
    }
}