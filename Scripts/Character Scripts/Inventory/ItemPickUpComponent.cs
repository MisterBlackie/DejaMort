using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InventoryComponent))]
public class ItemPickUpComponent : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Caméra du joueur")]
    private Camera playerCamera;

    [SerializeField]
    [Tooltip("Panneau affichant les infos de l'item")]
    private GameObject itemPickUpPanel;


    private InventoryComponent inventory;
    private GameObject itemBeingPickUp;

    public void Awake()
    {
        inventory = GetComponent<InventoryComponent>();
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

                if (item.GetComponent<ITakeable>() != null)
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

        if (inventory.AddItem(itemBeingPickUp.GetComponent<ITakeable>().item)) {
            Destroy(itemBeingPickUp);
            itemBeingPickUp = null;
            itemPickUpPanel.SetActive(false);
        }
    }
}
