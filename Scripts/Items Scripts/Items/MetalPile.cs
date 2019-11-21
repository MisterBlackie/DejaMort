using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalPile : MonoBehaviour, IItem
{
    public string itemUniqueCode { get => UniqueCode; private set { UniqueCode = value; } }
    public static string UniqueCode { get; private set; } = "METAL_PILE";
    public string itemName { get; private set; } = "Pile de métal";

    public string description { get; private set; } = "Un restant de métal utile pour fabriquer des items.";

    public Sprite displayImage { get; private set; }

    public bool hasBeenPickupOnce { get; private set; } = false;

    public void OnDrop()
    {
        gameObject.SetActive(true);
    }

    public void OnPickup()
    {
        gameObject.SetActive(false);
        hasBeenPickupOnce = true;
    }

    public void OnUse()
    {
        Destroy(this);
    }

    public bool Use()
    {
        return false;
        //OnUse();
    }


    void Awake()
    {
        displayImage = Resources.Load<Sprite>("Sprite/metalpile");
    }
}
