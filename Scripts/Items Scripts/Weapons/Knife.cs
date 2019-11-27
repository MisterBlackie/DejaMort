using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Knife : MonoBehaviour, IWeapon
{
    public string itemUniqueCode { get => UniqueCode; private set { UniqueCode = value; } }
    public static string UniqueCode { get; private set; } = "KNIFE";

    private Collider myCollider;
    private Rigidbody myRigibody;

    public int Damage { get; private set; } = 2;

    public int Durability { get; private set; } = 100;

    public string itemName { get; private set; } = "Couteau";

    public string description { get; private set; } = "Un couteau coupant.";

    public Sprite displayImage { get; private set; }

    public bool hasBeenPickupOnce { get; private set; } = false;

    public Vector3 HandPosition { get; private set; }

    public Vector3 ObjectRotation { get; private set; }

    public void Awake()
    {
        myRigibody = GetComponent<Rigidbody>();
        myCollider = GetComponent<Collider>();
        myRigibody.mass = 0;

        hasBeenPickupOnce = false;
        displayImage = Resources.Load<Sprite>("Sprite/knife");

        HandPosition = new Vector3(0.00104f, 0.001134f, -0.000117f);
        ObjectRotation = new Vector3(52.761f, 139.093f, 49.971f);
    }

    public bool isBroken() => Durability <= 0;

    public void Ranger()
    {
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
