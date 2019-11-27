﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class BasicSword : MonoBehaviour, IWeapon
{
    public string itemUniqueCode { get => UniqueCode; private set { UniqueCode = value; } }
    public static string UniqueCode { get; private set; } = "BASIC_SWORD";

    private Collider myCollider;
    private Rigidbody myRigibody;
    private Light myLight;
    public int Damage { get; private set; } = 5;

    public int Durability { get; private set; } = 100;

    public string itemName { get; private set; } = "Vielle épée";

    public string description { get; private set; } = "Une vielle épée qui ne fait pas beaucoup de dommage.";

    public Sprite displayImage { get; private set; }

    public bool hasBeenPickupOnce { get; private set; } = false;

    public Vector3 HandPosition { get; private set; }

    public Vector3 ObjectRotation { get; private set; }

    public void Awake()
    {
        myLight = GetComponent<Light>();
        myRigibody = GetComponent<Rigidbody>();
        myCollider = GetComponent<Collider>();
        myRigibody.mass = 0;
       
        hasBeenPickupOnce = false;
        displayImage = Resources.Load<Sprite>("Sprite/basicSword");

        HandPosition = new Vector3(0.000801f, 0.000545f, -0.000149f);
        ObjectRotation = new Vector3(-14.181f, 87.466f, 86.32001f);
    }
    public bool isBroken() => Durability <= 0;

    public void Ranger() {
        gameObject.SetActive(false);
    }

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
        Durability -= 1;
        
    }

    public void Repair(int RepairPts) => throw new System.NotImplementedException();

    public bool Use() // Équipe l'arme
    {
        myLight.enabled = false;
        myRigibody.mass = 1000;
        myCollider.enabled = false;
        transform.SetParent(PlayerComponent.instance.rightHandJoint.transform);
        PlayerComponent.instance.equippedItem = this;
        transform.localEulerAngles = ObjectRotation;
        transform.localPosition = HandPosition;
        gameObject.SetActive(true);
        return false;
    }

    public int UsePrimary()
    {
        myCollider.enabled = true;

        return isBroken() ? Damage / 2 : Damage;
    }

    public void EnleverCollider()
    {
        myCollider.enabled = false;
    }

    public int UseSecondary()
    {
        // Does nothing
        return 0;
    }
}
