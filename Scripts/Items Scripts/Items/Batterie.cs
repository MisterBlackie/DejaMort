﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batterie : MonoBehaviour, IItem
{
    public string itemUniqueCode { get => UniqueCode; private set { UniqueCode = value; } }
    public static string UniqueCode { get; private set; } = "BATTERIE";
    public string itemName { get; private set; } = "Batterie";

    public string description { get; private set; } = "Une source d'énergie miniature.";

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
        displayImage = Resources.Load<Sprite>("Sprite/batterie");
    }
}
