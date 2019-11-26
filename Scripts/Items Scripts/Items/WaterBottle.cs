﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBottle : MonoBehaviour, IFood
{
    public string itemUniqueCode { get => UniqueCode; private set { UniqueCode = value; } }
    public static string UniqueCode { get; private set; } = "WATER_BOTTLE";
    public string itemName { get; private set; } = "Bouteille d'eau";

    public string description { get; private set; } = "Pas très bon pour l'environnement.";

    public Sprite displayImage { get; private set; }

    public bool hasBeenPickupOnce { get; private set; } = false;
    public int FoodLevel { get; private set; } = 0;
    public int WaterLevel { get; private set; } = 500;

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
        displayImage = Resources.Load<Sprite>("Sprite/waterbottle");
    }
}
