using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour, IFood
{
    public string itemUniqueCode { get => UniqueCode; private set { UniqueCode = value; } }
    public static string UniqueCode { get; private set; } = "APPLE";
    public string itemName { get; private set; } = "Pomme";

    public string description { get; private set; } = "Une pomme par jour éloigne le médecin.";

    public Sprite displayImage { get; private set; }

    public bool hasBeenPickupOnce { get; private set; } = false;
    public int FoodLevel { get; private set; } = 50;
    public int WaterLevel { get; private set; } = 25;

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
        return true;
    }


    void Awake()
    {
        displayImage = Resources.Load<Sprite>("Sprite/apple");
    }
}
