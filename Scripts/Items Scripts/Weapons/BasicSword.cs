using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSword : MonoBehaviour, IWeapon
{

    private Collider myCollider;
    private Rigidbody myRigibody;
    public int Damage { get; private set; } = 10;

    public int Durability { get; private set; } = 100;

    public string itemName { get; private set; } = "Vielle épée";

    public string description { get; private set; } = "Une vielle épée qui ne fait pas beaucoup de dommage.";

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
        displayImage = Resources.Load<Sprite>("Sprite/basicSword");

        HandPosition = new Vector3(0.000801f, 0.000545f, -0.000149f);
        ObjectRotation = new Vector3(-14.181f, 87.466f, 86.32001f);
    }
    public bool isBroken() => Durability <= 0;

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
        return true;
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
